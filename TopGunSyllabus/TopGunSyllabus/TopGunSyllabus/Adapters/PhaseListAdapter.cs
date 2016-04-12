using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TopGunSyllabus.Core.Model;

namespace TopGunSyllabus.Adapters
{
    public class PhaseListAdapter: BaseAdapter<Phase>
    {
        private List<Phase> items;
        private Activity context;

        public PhaseListAdapter(Activity context, List<Phase> items ) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Phase this [int position]
        {
            get
            {
                return items[position]; 
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text =
                item.Name;
            return convertView;
        }
    }
}