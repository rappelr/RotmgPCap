using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Packets.DataTypes.Primitive;
using System.Windows.Forms;

namespace RotmgPCap.Forms.Components
{
    class PacketObjectNode : TreeNode
    {
        internal readonly string ObjectName, Type, Value;
        internal readonly int DataIndex, Length;
        internal readonly bool Container, Header, Failure;

        internal PacketObjectNode(TypeInstance typeInstance) : base()
        {
            ObjectName = typeInstance.Name;
            Type = typeInstance.Type.Name;

            Text = ObjectName;

            if (typeInstance.Type is AVoid)
                ForeColor = System.Drawing.Color.Gray;

            if (typeInstance.Result == null)
            {
                ForeColor = System.Drawing.Color.Gray;
                Length = 0;
                Value = "Unreachable";
                return;
            }

            DataIndex = typeInstance.Result.StreamPosition;
            Length = typeInstance.Result.BytesRead;
            Failure = typeInstance.Result.Error;

            Container = typeInstance.Result.RawValue is TypeInstance[];
            Header = typeInstance.Type.Name == "PacketHeader"; //fuck you
            Value = Container ? "Object list" : Failure ? typeInstance.Result.ErrorMessage : typeInstance.Result.StringValue;

            if (Failure)
                ForeColor = System.Drawing.Color.Red;

            if (Container)
            {
                foreach (TypeInstance child in typeInstance.Result.RawValue as TypeInstance[])
                {
                    Nodes.Add(new PacketObjectNode(child));

                    if (child.Result.Error)
                        break;
                }
            }
        }
    }
}
