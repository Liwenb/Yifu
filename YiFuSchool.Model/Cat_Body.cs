using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiFuSchool.Model
{
    public class Cat_Body
    {
        public Cat_Body() { }


        /// <summary>
        /// auto_increment
        /// </summary>
        public int? cat_body_id { get; set; }



        /// <summary>
        /// cat_id
        /// </summary>
        public int? cat_id { get; set; }



        /// <summary>
        /// cat_body_title
        /// </summary>
        public string cat_body_title { get; set; }



        /// <summary>
        /// cat_body_author
        /// </summary>
        public string cat_body_author { get; set; }



        /// <summary>
        /// cat_body_type
        /// </summary>
        public string cat_body_type { get; set; }



        /// <summary>
        /// cat_body_url
        /// </summary>
        public string cat_body_url { get; set; }



        /// <summary>
        /// cat_body_keyword
        /// </summary>
        public string cat_body_keyword { get; set; }



        /// <summary>
        /// cat_body_content
        /// </summary>
        public string cat_body_content { get; set; }



        /// <summary>
        /// cat_body_indate
        /// </summary>
        public string cat_body_indate { get; set; }



        /// <summary>
        /// cat_body_outdate
        /// </summary>
        public string cat_body_outdate { get; set; }



        /// <summary>
        /// cat_body_click
        /// </summary>
        public int? cat_body_click { get; set; }



        /// <summary>
        /// cat_body_recommend
        /// </summary>
        public int? cat_body_recommend { get; set; }



        /// <summary>
        /// cat_body_confirm
        /// </summary>
        public int? cat_body_confirm { get; set; }



        /// <summary>
        /// cat_body_icon
        /// </summary>
        public string cat_body_icon { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
