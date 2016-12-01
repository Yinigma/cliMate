using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCeres
{
    public class FileNode : InputNode
    {
        public const int SCALE = 0;
        public const int CROP = 1;
        public Bitmap image;

        public FileNode(NodeMap map, String fileName) : base(map)
        {
            image = null;
        }

        

        public override void doOperation()
        {

        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            FileForm fileWin = new FileForm(this);
            fileWin.ShowDialog();
            //doOperation();
        }
    }
}
