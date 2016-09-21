using Xamarin.Forms;

namespace XamlEx
{
    public class CourseCell : ViewCell
    {
        public CourseCell()
        {
            var titleLabel = new Label
            {
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium)
            };
            titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));

            var authorLabel = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Micro),
                XAlign = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            authorLabel.SetBinding(Label.TextProperty, new Binding("Author"));

            View = new StackLayout
            {
                Children = {titleLabel,authorLabel},
                Orientation = StackOrientation.Horizontal
            };
        }
    }

}
