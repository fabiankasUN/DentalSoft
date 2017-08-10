using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ViewModels.Client;
using ViewModels.Odontogram;
using ViewModels.Users;

namespace DentalService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DentalService : IDentalService {
       

        private DentalModeldb _db;

        public DentalService( ) {
            _db = new DentalModeldb( );
        }

        #region Users
        public void CreateUser( int id_client, UserVM user ) {

        }

        public UserVM GetUser( int id_user ) {
            return null;
        }

        public UserVM GetUserLogin( string login ) {
            return null;
        }

        public List<UserVM> GetUsersClient( int id_client ) {
            return null;
        }

        public List<UserVM> GetUsers( bool active ) {
            return null;
        }
        #endregion

        #region Clients

        private void ExistClient( int id_client ) {
            bool exist = _db.Client.Any( x => x.Id_Client == id_client );
            if ( !exist )
                throw new Exception( );
        }

        public void CreateClient( ClientVM client ) {

            try {
                ExistClient( client.Id_Client );

                Client newClient = new Client {
                    Code = client.Code,
                    Name = client.Name,
                    Active = client.Active
                };

            } catch (Exception ex) {

            }


        }


        public void UpdateClient( ClientVM client ) {

        }

        public void ActivateClient( int id_client ) {

        }

        public List<ClientVM> GetClients( bool active ) {
            return null;
        }
        #endregion

        #region Patients

        #endregion

        #region Odontogram

        private void AddTooth( int start, int end, Odontogram o ) {
            for ( int i = start; i < end; i++ ) {
                o.Teeth.Add( new Teeth {
                    Id_Teeth = i,
                    Id_Odontogram = o.Id_Odontogram,
                    UpperCervical = 0,
                    Vestibular = 0,
                    Oclusal = 0,
                    Palatino = 0,
                    Distal = 0,
                    Mesial = 0,
                    LowerServical = 0,
                    General = 0
                } );
                
            }
        }

        public void CreateOdontogram( int id_patient ) {
            try {
                Odontogram odontogram = new Odontogram {
                    Id_patient = id_patient,
                    first = true,
                    CreationDate = DateTime.Now,
                };
                AddTooth( 11, 18, odontogram );
                AddTooth( 21, 28, odontogram );
                AddTooth( 51, 55, odontogram );
                AddTooth( 61, 65, odontogram );
                AddTooth( 81, 85, odontogram );
                AddTooth( 71, 75, odontogram );
                AddTooth( 41, 48, odontogram );
                AddTooth( 31, 38, odontogram );
            } catch( Exception ex) {
                throw new Exception( ex.Message );
            }

        }

        public OdontogramVM GetOdontogram( int id_patient, bool first ) {
            throw new NotImplementedException( );
        }

        public void UpdateOdontogram( int id_patient ) {
            throw new NotImplementedException( );
        }

        public List<OdontogramActionVM> GetOdontogramActions( ) {

            List<OdontogramActionVM> OActionVM = null;
            try {
                List<OdontogramAction> list = _db.OdontogramAction.ToList( );
                OActionVM = new List<OdontogramActionVM>( );
                foreach ( OdontogramAction oa in list ) {
                    OActionVM.Add( new OdontogramActionVM {
                        Id_action = oa.Id_action,
                        Code = oa.Code,
                        Name = oa.Name,
                        shorcut = oa.shorcut
                    } );
                }

            } catch ( Exception ex) {
                throw new Exception( ex.Message );
            }
            return OActionVM;
        }

        #endregion

        #region Service
        #endregion

        #region Appointment
        #endregion

        #region StateAppointment
        #endregion
    }
}
