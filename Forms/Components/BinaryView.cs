using System;
using System.Drawing;
using System.Windows.Forms;

namespace RotmgPCap.Forms.Components
{
    public class BinaryView : PictureBox
    {
        private const int BORDER = 8;
        private const int HEX_OFFSET = BORDER + 60;
        private const int UTF_OFFSET = BORDER + 400;
        private const int ROW_HEIGHT = 18;

        internal bool HexMode { get; private set; }
        internal int SelectionStart {get; private set; }
        internal int SelectionStop { get; private set; }
        internal int SelectionIndex { get; private set; }

        private static readonly Font font = new Font("Courier New", 9, FontStyle.Regular);
        private static readonly Brush brushBlack = new SolidBrush(Color.Black);
        private static readonly Brush brushRed = new SolidBrush(Color.Red);
        private static readonly Brush brushGray = new SolidBrush(Color.DarkGray);
        private static readonly Brush brushBlue = new SolidBrush(Color.RoyalBlue);
        private static readonly Brush brushGreen = new SolidBrush(Color.LimeGreen);
        private static readonly Brush brushYellow = new SolidBrush(Color.Yellow);
        private static readonly Brush brushPurple = new SolidBrush(Color.Orchid);
        private static readonly Brush brushWhite = new SolidBrush(Color.White);
        private static readonly Pen penBorder = new Pen(Color.DarkGray, 3f);

        private OnSelect onSelect;
        private string[] data, dataChars;
        private SelectionType selectionType;
        private int scroll, drawHeight, maxScroll;

        public BinaryView() : base() {
            MouseWheel += new MouseEventHandler(OnScroll);
            MouseClick += new MouseEventHandler(OnClick);
        }

        internal void SetData(byte[] data)
        {
            this.data = BitConverter.ToString(data).Split('-');

            dataChars = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
                dataChars[i] = data[i] > 32 && data[i] < 128 ? Convert.ToChar(data[i]).ToString() : ".";

            scroll = 0;
            CalculateDrawHeight();
            OnResize();
        }

        internal void SetOnSelect(OnSelect onSelect) => this.onSelect = onSelect;

        internal void Select(SelectionType type, int index, int length, int? internalIndex = null)
        {
            selectionType = type;
            SelectionStart = index;
            SelectionStop = index + length;
            SelectionIndex = internalIndex ?? SelectionStart;

            if (SelectionStop > (scroll + drawHeight) * 16 || SelectionStart < scroll * 16)
            {
                CalculateDrawHeight();
                scroll = Math.Max(0,Math.Min(maxScroll, (int)Math.Floor(SelectionStart / 16d)));
            }
            
            Render();
        }

        internal void SetHexMode(bool hexMode)
        {
            HexMode = hexMode;
            Render();
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= UTF_OFFSET)
            {
                int x = (int)Math.Floor((e.Location.X - UTF_OFFSET) / 8d);

                if (x >= 16)
                    return;

                int y = (int)Math.Floor((e.Location.Y - BORDER) / 18d) + scroll;
                int i = x + 16 * y;

                if (i < 0 || y >= data.Length)
                    return;

                (SelectionType type, int index, int length) = onSelect.Invoke(i);
                Select(type, index, length, i);
            }
            else if(e.Location.X >= HEX_OFFSET)
            {
                int x = (int)Math.Floor((e.Location.X - HEX_OFFSET) / 20d);

                if (x >= 16)
                    return;

                int y = (int)Math.Floor((e.Location.Y - BORDER) / 18d) + scroll;
                int i = x + 16 * y;

                if (i < 0 || y >= data.Length)
                    return;

                (SelectionType type, int index, int length) = onSelect.Invoke(i);
                Select(type, index, length, i);
            }
        }

        private void OnScroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (scroll > 0)
                    scroll--;
            }
            else if (scroll < maxScroll)
                scroll++;

            Render();
        }

        internal void OnResize()
        {
            CalculateDrawHeight();
            Render();
        }

        internal void Deselect() => selectionType = SelectionType.NOTHING;

        private void Render()
        {
            if (data == null || Width <= 0 || Height <= 0)
                return;

            bool singleSelection = SelectionStart == SelectionStop;

            using (var bmp = new Bitmap(Width, Height))
            {
                using (var gfx = Graphics.FromImage(bmp))
                {
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    gfx.Clear(Color.White);

                    int index = 0;
                    for (int vy = 0; vy < drawHeight && index < data.Length; vy++)
                    {
                        int y = vy + scroll;

                        if(HexMode)
                            gfx.DrawString((y * 16).ToString("X5"), font, brushBlack, BORDER, BORDER + vy * ROW_HEIGHT);
                        else
                            gfx.DrawString((y * 16).ToString().PadLeft(5, '0'), font, brushBlack, BORDER, BORDER + vy * ROW_HEIGHT);

                        for (int x = 0; x < 16; x++)
                        {
                            index = y * 16 + x;

                            if (index >= data.Length)
                                break;

                            if (selectionType != SelectionType.NOTHING && index >= SelectionStart && index < SelectionStop)
                            {
                                Brush back, front;

                                switch (selectionType)
                                {
                                    case SelectionType.TYPE:
                                        back = brushBlue;
                                        break;
                                    case SelectionType.CONTAINER:
                                        back = brushGreen;
                                        break;
                                    case SelectionType.MANUAL:
                                        back = brushYellow;
                                        break;
                                    case SelectionType.PACKET_HEADER:
                                        back = brushPurple;
                                        break;
                                    case SelectionType.FAILURE:
                                        back = brushRed;
                                        break;
                                    default:
                                        back = brushGray;
                                        break;
                                }

                                front = selectionType == SelectionType.MANUAL ? brushBlack : brushWhite;

                                gfx.FillRectangle(back, HEX_OFFSET + x * 20 - 1, BORDER + vy * 18 - 2, 22, 19);
                                gfx.DrawString(data[index], font, front, HEX_OFFSET + x * 20, BORDER + vy * 18);
                                gfx.FillRectangle(back, UTF_OFFSET + x * 8, BORDER + vy * 18 - 2, 9, 19);
                                gfx.DrawString(dataChars[index], font, front, UTF_OFFSET + x * 8, BORDER + vy * 18);
                            }
                            else
                            {
                                gfx.DrawString(data[index], font, brushBlack, HEX_OFFSET + x * 20, BORDER + vy * 18);
                                gfx.DrawString(dataChars[index], font, brushBlack, UTF_OFFSET + x * 8, BORDER + vy * 18);
                            }
                        }
                    }

                    if (selectionType != SelectionType.NOTHING && selectionType != SelectionType.UNKNOWN)
                    {
                        int x = SelectionIndex % 16;
                        int y = (SelectionIndex - x) / 16 - scroll;

                        gfx.DrawRectangle(penBorder, HEX_OFFSET + x * 20 - 2, BORDER + y * 18 - 2, (singleSelection ? 2 : 23), 19);
                        gfx.DrawRectangle(penBorder, UTF_OFFSET + x * 8, BORDER + y * 18 - 2, (singleSelection ? 2 : 10), 19);
                    }

                    Image?.Dispose();
                    Image = (Bitmap)bmp.Clone();
                }
            }
        }

        private void CalculateDrawHeight()
        {
            drawHeight = (int)Math.Floor((Height - 2 * BORDER) / (double)ROW_HEIGHT);
            maxScroll = (int)Math.Ceiling(data.Length / 16d) - drawHeight;

            if (maxScroll > 0 && scroll > maxScroll)
                scroll = maxScroll;
        }
    }

    internal delegate (SelectionType type, int startIndex, int length) OnSelect(int index);

    internal enum SelectionType
    {
        NOTHING,
        TYPE,
        PACKET_HEADER,
        CONTAINER,
        MANUAL,
        FAILURE,
        UNKNOWN
    }
}
