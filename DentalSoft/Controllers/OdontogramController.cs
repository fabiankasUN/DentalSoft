using Data;
using DentalSoft.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ViewModels.Odontogram;

namespace DentalSoft.Controllers
{
    public class OdontogramController : Controller
    {
        // GET: Odontogram
        public ActionResult Index()
        {
            return View();
        }
        /*public class Odontogram {

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
                    
                    int a = r.Next( 1, 3 );
                    int b = r.Next( 1, 3 );
                    int c = r.Next( 1, 3 );
                    upperTeeth[i] = new Teeth(a,b,c,a,b);
                    lowerTeeth[i] = new Teeth( a, b, c, a,b );
                    if ( i < 10 ) {
                        upperTemporalTeeth[i] = new Teeth( a, b, c, a ,b);
                        lowerTemporalTeeth[i] = new Teeth( a, b, c, a,b );
                    }
                    Debug.Write( a );
                }
            }
            public class Teeth {
                public int Id { get; set; }
                public int UpperCervical { get; set; }
                public int LowerCervical { get; set; }
                public int Vertibular { get; set; }
                public int Oclusal { get; set; }
                public int Palatino { get; set; }
                public int Distal { get; set; }
                public int Mesial { get; set; }
                public int General { get; set; }
                public Teeth(int top,int buttom,int left, int right, int id ) {
                    this.UpperCervical = top;
                    this.LowerCervical = buttom;
                    this.Vertibular = left;
                    this.Oclusal = right;
                    //this.color = "blue";
                    this.Id = id;
                    this.General = 1;
                }
            }

            public string toString( ) {
                return upperTeeth[0].UpperCervical+"";
            }
        }*/
        //GET /Odontogram/GetOdontogram
        [HttpGet]
        public JsonResult GetOdontogram( ) {
            //Odontogram o = new Odontogram( );
            DentalService.DentalService client = new DentalService.DentalService( );
            OdontogramVM o= client.GetOdontogram(1, true );
            //foreach ( OdontogramActionVM v in d.GetOdontogramActions() ) {
            //    Debug.Write( v.Code );
            //}
            //Odontogram o = new Odontogram( );
            return Json( o, JsonRequestBehavior.AllowGet );
        }
    }
}