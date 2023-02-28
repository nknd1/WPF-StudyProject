using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNikiforov
{
    public class Pages
    {
        private static dbconn dbconnection;
        private static StPage startPage;
        private static CatPage catPage;
        private static ProdPage prodPage;
        private static ProductList prodPreview;
        private static ProductEdit productEdit;
        public static dbconn dbconn
        {
            get
            {
                if (dbconnection == null)
                {
                    dbconnection = new dbconn();
                }
                return dbconnection;
            }

            set
            {
                dbconnection = value;
            }
        }

        public static StPage Start
        {
            get
            {
                if (startPage == null)
                {
                    startPage = new StPage();
                }
                return startPage;
            }
        }
        public static CatPage Cat
        {
            get
            {
                if (catPage == null)
                {
                    catPage = new CatPage(dbconn);
                }
                return catPage;
            }

        }
        public static ProdPage Prod
        {
            get
            {
                if (prodPage == null)
                {
                    prodPage = new ProdPage(dbconn);
                }
                return prodPage;
            }
        }
        public static ProductList List
        {

            get
            {
                if (prodPreview == null)
                {
                    prodPreview = new ProductList(dbconn);
                }
                return prodPreview;
            }

        }
        public static ProductEdit Edit
        {
            get
            {
                if(productEdit == null) 
                {
                    productEdit = new ProductEdit(dbconn);
                }
                return productEdit;
            }
            
        }
    }
}
