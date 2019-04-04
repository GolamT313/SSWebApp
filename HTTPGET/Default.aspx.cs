using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace HTTPGET
{

    public partial class _Default : Page
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string Host = "https://api.ssactivewear.com";
        
        public void Page_Load(object sender, EventArgs e)
        {

            string URLPath = String.Format("/v2/products/B00760004");
            WebRequest requestObjGet = WebRequest.Create(Host + URLPath);
            requestObjGet.Credentials = new NetworkCredential("89105", "cf7631ab-1acc-4ef3-830e-68a21aba533a");

            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            List<Sku> Products = new List<Sku>();

            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                var result = sr.ReadToEnd();
                sr.Close();

                if (responseObjGet.StatusCode == HttpStatusCode.OK)
                {
                    Products = serializer.Deserialize<List<Sku>>(result);

                    contentDiv.InnerHtml = result;


                }
                

            }

        }

        public class Sku
        {

            public string sku { get; set; }
            public string gtin { get; set; }
            public string yourSku { get; set; }

            public int? styleID { get; set; }
            public string brandName { get; set; }
            public string styleName { get; set; }

            public string colorName { get; set; }
            public string colorCode { get; set; }
            public string colorPriceCodeName { get; set; }
            public string colorGroup { get; set; }
            public string colorFamily { get; set; }
            public string colorSwatchImage { get; set; }
            public string colorSwatchTextColor { get; set; }
            public string colorFrontImage { get; set; }
            public string colorSideImage { get; set; }
            public string colorBackImage { get; set; }
            public string color1 { get; set; }
            public string color2 { get; set; }

            public string sizeName { get; set; }
            public string sieCode { get; set; }
            public string sizeOrder { get; set; }
            public string sizePriceCodeName { get; set; }

            public int? caseQty { get; set; }
            public decimal? unitWeight { get; set; }


            public decimal? piecePrice { get; set; }
            public decimal? dozenPrice { get; set; }
            public decimal? casePrice { get; set; }
            public decimal? salePrice { get; set; }
            public decimal? customerPrice { get; set; }
            public System.DateTime? saleExpiration { get; set; }



        }
    }
}
