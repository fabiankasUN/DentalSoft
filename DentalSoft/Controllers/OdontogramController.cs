using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DentalSoft.Controllers
{
    public class OdontogramController : Controller
    {
        // GET: Odontogram
        public ActionResult Index()
        {
            return View();
        }
        public class Odontogram {

            public Teeth [] upperTeeth { get; set;}
            public Teeth[] upperTemporalTeeth { get; set; }
            public Teeth[] lowerTemporalTeeth { get; set; }
            public Teeth[] lowerTeeth { get; set; }
            public Odontogram(){
                upperTeeth = new Teeth[16];
                upperTemporalTeeth = new Teeth[10];
                lowerTemporalTeeth = new Teeth[10];
                lowerTeeth = new Teeth[16];
                Random r = new Random( );
                for ( int i= 0; i < 16; i++ ) {
                    
                    int a = r.Next( 1, 10 );
                    int b = r.Next( 1, 10 );
                    int c = r.Next( 1, 10 );
                    upperTeeth[i] = new Teeth(a,b,c,a);
                    lowerTeeth[i] = new Teeth( a, b, c, a );
                    if ( i < 10 ) {
                        upperTemporalTeeth[i] = new Teeth( a, b, c, a );
                        lowerTemporalTeeth[i] = new Teeth( a, b, c, a );
                    }
                    Debug.Write( a );
                }
            }
            public class Teeth {
                public int top { get; set; }
                public int buttom { get; set; }
                public int left { get; set; }
               public  int right { get; set; }
                public Teeth(int top,int buttom,int left, int right ) {
                    this.top = top;
                    this.buttom = buttom;
                    this.left = left;
                    this.right = right;
                }
            }

            public string toString( ) {
                return upperTeeth[0].top+"";
            }
        }
        //GET /Odontogram/GetOdontogram
        [HttpGet]
        public JsonResult GetOdontogram( ) {
            Odontogram o = new Odontogram( );
            return Json( o, JsonRequestBehavior.AllowGet );
        }



    }
}