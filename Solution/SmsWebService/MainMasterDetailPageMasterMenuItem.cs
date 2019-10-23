using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsWebService
{

    public class MainMasterDetailPageMasterMenuItem
    {
        public MainMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(MainMasterDetailPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}