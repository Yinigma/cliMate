using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCeres
{
    public class DrawNode : InputNode
    {
        public bool editedOnce = false;     //Whether or not the user has already drawn something.  This way we can edit instead of creating something new.

        //Expose outGrid so we can edit it in Canvas
        public RectGrid Grid
        {
            get { return outGrid; }
            set { outGrid = value; }
        }

        public DrawNode(NodeMap map) : base(map)
        {
        }

        public override void doOperation()
        {
            throw new NotImplementedException();
        }

        public override int getOptional()
        {
            return 0;
        }

        public override void openForm()
        {
            Canvas canvas = new Canvas(this);
            canvas.ShowDialog();
            editedOnce = true;
        }
    }
}
