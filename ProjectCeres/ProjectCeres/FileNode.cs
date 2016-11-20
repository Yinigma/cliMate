using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class FileNode : InputNode
    {
        public Bitmap image;

        public FileNode(NodeMap map, String fileName) : base(map)
        {
            //image = new Bitmap(fileName);

        }

        

        public override void doOperation()
        {
            //TODO Slap the file import logic here and put it into the output grid
            throw new NotImplementedException();
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            return;
        }
    }
}
