using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiIOSCollectionViewScrolled
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<CVItem> items = new ObservableCollection<CVItem>();

        ObservableCollection<CVGroup> groupedItems = new ObservableCollection<CVGroup>();
        public MainPage()
        {
            InitializeComponent();

            for (int group = 0; group < 50; group++)
            {
                List<CVItem> groupItems = new List<CVItem>();
                for (int i = 0; i < 20; i++)
                {
                    //groupItems.Add(new CVItem
                    //{
                    //    Text = $"Item {i} in Group {group}",
                    //    Description = $"Description for Item {i} in Group {group}",
                    //    GroupID = group.ToString()
                    //});
                }
                groupedItems.Add(new CVGroup($"Group {group}", groupItems));
            } 

            cv.ItemsSource = groupedItems;

        }

        private void cv_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Trace.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.ffff")} cv_Scrolled triggered");
        }
    }

    public class CVItem
    {
        public string Text { get; set; } = "";
        public string Description { get; set; } = "";

        public string GroupID { get; set; } = "";

        public bool IsVisible { get; set; } = false;
    }

    public class CVGroup : List<CVItem>
    {
        public string Title { get; set; } = "";

        public CVGroup(string Title, List<CVItem> items) : base(items)
        {
            this.Title = Title;
        }
    }
}