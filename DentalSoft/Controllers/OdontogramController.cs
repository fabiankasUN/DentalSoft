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

            public Teeth [] tooth { get; set;}
            public Odontogram(){
                tooth = new Teeth[8];
                Random r = new Random( );
                for ( int i= 0; i < 8; i++ ) {
                    
                    int a = r.Next( 1, 10 );
                    int b = r.Next( 1, 10 );
                    int c = r.Next( 1, 10 );
                    tooth[i] = new Teeth(a,b,c,a);
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
                return tooth[0].top+"";
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