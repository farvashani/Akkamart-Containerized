using System;
using System.Collections.Generic;
using System.Text;

namespace Messangers {
    public class RequestModel {

        /// <summary>
        /// شماره دریافت کننده
        /// </summary>
        public string[] receptor { get; set; }

        /// <summary>
        /// شماره خط ارسال کننده پیام 
        /// </summary>
        public string[] sender { get; set; }

        /// <summary>
        /// متن پیام کوتاه
        /// </summary>
        public string[] message { get; set; }

        /// <summary>
        /// زمان ارسال پیام - در صورتی که خالی باشد پیام به صورت خودکار در همان لحظه ارسال می شود 
        /// UnixTime ( Timestamp integer )
        /// </summary>        
        public Int32 date { get; set; }

        /// <summary>
        /// نوع پیام در گوشی گیرنده می باشد (جدول شماره 3) فقط برای خطوط 3000 امکان پذیر است 
        /// </summary>
        public int[] type { get; set; }

        /// <summary>
        /// شناسه محلی در پایگاه داده های ما
        /// </summary>
        public string[] localid { get; set; }

        /// <summary>
        /// شماره خط مورد نظر مثل 30002225 
        /// </summary>
        public string linenumber { get; set; }

        /// <summary>
        /// خوانده شده : 1 ، خوانده نشده : 0 
        /// </summary>
        public int isread { get; set; }

    }
    public class SMSCallBackModel {
        public string from { get; set; }

        public string to { get; set; }

        public string message { get; set; }

        public string messageid { get; set; }

    }
}