using JarvisEF.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JarvisEF.AdminUI.Models.Common
{
    public class MemberViewModel
    {

        #region ID/PW 찾기
        #region [ 핸드폰 ]
        public IEnumerable<DropDownItem> SelectCP { get; set; }
        #endregion

        #region [생년월일]
        public IEnumerable<DropDownItem> SelectedYear { get; set; }
        public IEnumerable<DropDownItem> SelectedMonth { get; set; }
        public IEnumerable<DropDownItem> SelectedDay { get; set; }
        #endregion

        public int? Setp { get; set; }
        public int? ID_Find_Type { get; set; }

        public int? PW_Find_Type { get; set; }

        private bool _IsIDNonSetting = false;

        public bool IsIDNonSetting
        {
            get { return _IsIDNonSetting; }
            set { this._IsIDNonSetting = value; }
        }

        private bool _IsPWNonSetting = false;
        public bool IsPWNonSetting
        {
            get { return _IsPWNonSetting; }
            set { this._IsPWNonSetting = value; }
        }

        public string Referrer { get; set; }
        #endregion

    }
}
