using Data.Entities;
using Data.Exceptions;
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
using System.Globalization;
using System.Threading;
using Data.Resources.Client;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace DentalService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DentalService : IDentalService {
       

        private DentalModeldb _udt;
        private readonly Dictionary<int,int> _UpperMap = new Dictionary<int, int> {
            {18,0}, {17,1}, {16,2}, {15,3}, {14,4}, {13,5}, {12,6}, {11,7},
            { 21,8}, {22,9}, {23,10}, {24,11}, {25,12}, {26,13}, {27,14}, {28,15}
        };
        private readonly Dictionary<int, int> _UpperTemporalMap = new Dictionary<int, int> {
            {55,0}, {54,1}, {53,2}, {52,3}, {51,4}, {61,5}, {62,6}, {63,7},
            { 64,8}, {65,9 }
        };
        private readonly Dictionary<int, int> _LowerTemporalMap = new Dictionary<int, int> {
            {85,0}, {84,1}, {83,2}, {82,3}, {81,4}, {71,5}, {72,6}, {73,7},
            { 74,8}, {75,9}
        };
        private readonly Dictionary<int, int> _LowerMap = new Dictionary<int, int> {
            {48,0}, {47,1}, {46,2}, {45,3}, {44,4}, {43,5}, {42,6}, {41,7},
            { 31,8}, {32,9}, {33,10}, {34,11}, {35,12}, {36,13}, {37,14}, {38,15}
        };


        public DentalService( ) {
            _udt = new DentalModeldb( );
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

        public List<UserVM> GetUsers( int id_client, bool active ) {
            return null;
        }
        #endregion

        #region Clients

        private void NotExistClient( int id_client ) {
            bool exist = _udt.Client.Any( x => x.Id_Client == id_client );
            if ( exist )
                throw new ValidationException( ClientResources.NotExistClient );
        }

        public void CreateClient( ClientVM client ) {

            try {
                NotExistClient( client.Id_Client );

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

                _udt.Odontogram.Add( odontogram );
                SaveChanges( );
            } catch( Exception ex) {
                throw new ValidationException( ex.Message );
            }
        }

        public OdontogramVM GetOdontogram( int id_patient, bool first ) {

            OdontogramVM odontogramVM = null;
            try {
                Odontogram odontogram = _udt.Odontogram.Where( x => x.Id_patient == id_patient && x.first == first ).FirstOrDefault();
                if( odontogram != null ) {
                    odontogramVM = new OdontogramVM( );
                    odontogramVM.upperTeeth = new TeethVM[16];
                    odontogramVM.upperTemporalTeeth = new TeethVM[10];
                    odontogramVM.lowerTemporalTeeth = new TeethVM[10];
                    odontogramVM.lowerTeeth = new TeethVM[16];
                    
                    foreach( Teeth teeth in odontogram.Teeth ) {
                        AddTeeth( odontogramVM, teeth );
                    }
                    odontogramVM.actions = GetOdontogramActions( );
                    odontogramVM.treatment = GetOdontogramTreatments( );
                }
            } catch ( Exception ex) {
                throw new ValidationException( ex.Message );
            }
            return odontogramVM;
        }

        public void UpdateOdontogram( int id_patient ) {
            throw new NotImplementedException( );
        }

        private void AddTeeth( OdontogramVM o, Teeth teeth ) {
            TeethVM teethVM = new TeethVM {
                Id_Teeth = teeth.Id_Teeth,
                Id_Odontogram = teeth.Id_Odontogram,
                UpperCervical = teeth.UpperCervical,
                Vestibular = teeth.Vestibular,
                Oclusal = teeth.Oclusal,
                Palatino = teeth.Palatino,
                Distal = teeth.Distal,
                Mesial = teeth.Mesial,
                LowerServical = teeth.LowerServical,
                General = teeth.General
            };
            if ( _UpperMap.ContainsKey( teeth.Id_Teeth ) )
                o.upperTeeth[_UpperMap[teeth.Id_Teeth]] = teethVM;
            if ( _UpperTemporalMap.ContainsKey( teeth.Id_Teeth ) )
                o.upperTemporalTeeth[_UpperTemporalMap[teeth.Id_Teeth]] = teethVM;
            if ( _LowerTemporalMap.ContainsKey( teeth.Id_Teeth ) )
                o.lowerTemporalTeeth[_LowerTemporalMap[teeth.Id_Teeth]] = teethVM;
            if ( _LowerMap.ContainsKey( teeth.Id_Teeth ) )
                o.lowerTeeth[_LowerMap[teeth.Id_Teeth]] = teethVM;
        }


        #endregion

        #region Odontogram Actions
        public List<OdontogramActionVM> GetOdontogramActions( ) {

            List<OdontogramActionVM> OActionVM = null;
            try {
                List<OdontogramAction> list = _udt.OdontogramAction.ToList( );
                OActionVM = new List<OdontogramActionVM>( );
                foreach ( OdontogramAction oa in list ) {
                    OActionVM.Add( new OdontogramActionVM {
                        Id_action = oa.Id_action,
                        Code = oa.Code,
                        Name = oa.Name,
                        shorcut = oa.shorcut
                    } );
                }

            } catch ( Exception ex ) {
                throw new Exception( ex.Message );
            }
            return OActionVM;
        }

        #endregion

        #region Odontogram Treatments
        public List<OdontogramTreatmentVM> GetOdontogramTreatments( ) {
            List<OdontogramTreatmentVM> OTreatment = null;
            try {
                List<OdontogramTreatment> list = _udt.OdontogramTreatment.ToList( );
                OTreatment = new List<OdontogramTreatmentVM>( );
                foreach ( OdontogramTreatment ot in list ) {
                    OTreatment.Add( new OdontogramTreatmentVM {
                        Id_Treatment = ot.Id_Treatment,
                        Code = ot.Code,
                        Name = ot.Name,
                        type = ot.type
                    } );
                }

            } catch ( Exception ex ) {
                throw new Exception( ex.Message );
            }
            return OTreatment;
        }
        #endregion

        #region Service
        #endregion

        #region Appointment
        #endregion

        #region StateAppointment
        #endregion




        private void SaveChanges( ) {

            try {
                _udt.SaveChanges( );
            } catch ( DbEntityValidationException ex ) {
                
                foreach ( DbEntityValidationResult item in ex.EntityValidationErrors ) {
                    // Get entry
                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType( ).Name;

                    // Display or log error messages

                    foreach ( DbValidationError subItem in item.ValidationErrors ) {
                        string message = string.Format( "Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName );
                        Console.WriteLine( message );
                    }
                }
            }
            
        }


    }
}
