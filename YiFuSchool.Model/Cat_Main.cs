using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiFuSchool.Model
{
    public class Cat_Main
    {

        public Cat_Main() { }


        /// <summary>
        /// auto_increment
        /// </summary>
        public int? cat_id { get; set; }



        /// <summary>
        /// cat_name
        /// </summary>
        public string cat_name { get; set; }



        /// <summary>
        /// cat_thread_id
        /// </summary>
        public int? cat_thread_id { get; set; }



        /// <summary>
        /// cat_parent_id
        /// </summary>
        public int? cat_parent_id { get; set; }
        public string cat_parent_ids { get; set; }



        /// <summary>
        /// cat_user_type
        /// </summary>
        public string cat_user_type { get; set; }



        /// <summary>
        /// cat_header_tpl_id
        /// </summary>
        public int? cat_header_tpl_id { get; set; }



        /// <summary>
        /// cat_footer_tpl_id
        /// </summary>
        public int? cat_footer_tpl_id { get; set; }



        /// <summary>
        /// cat_confirm
        /// </summary>
        public int? cat_confirm { get; set; }



        /// <summary>
        /// cat_order
        /// </summary>
        public int? cat_order { get; set; }

    }
}
