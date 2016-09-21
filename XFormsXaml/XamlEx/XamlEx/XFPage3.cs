using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlEx
{
    public class XFPage3 : ContentPage
    {
        public XFPage3()
        {
            var layout = new RelativeLayout();
            var label = new Label()
            {
                Text = "This is a line of text!"
            };
            layout.Children.Add(label, Constraint.Constant(0),
                Constraint.RelativeToParent(parent => parent.Height / 2));

            var label2 = new Label() { Text = "More text over here!" };

            layout.Children.Add(label2, Constraint.RelativeToView(label, (parent, otherView) => otherView.X + otherView.Width), Constraint.RelativeToView(label, (parent, otherView) => otherView.Y - otherView.Height));

            var label3 = new Label() { Text = "Final text" };

            layout.Children.Add(label3, Constraint.RelativeToView(label2, (parent, otherView) =>
            {
                return (otherView.X + otherView.Width) - label3.Width;
            }),
                Constraint.RelativeToView(label, (parent, otherView) => { return otherView.Y; }));

            label3.SizeChanged += (o, e) => { layout.ForceLayout(); };

            Content = layout;
        }
    }
}
