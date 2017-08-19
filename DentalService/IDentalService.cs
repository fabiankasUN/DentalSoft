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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDentalService {

        #region Users
        [OperationContract]
        void CreateUser( int id_client, UserVM user );

        [OperationContract]
        UserVM GetUser( int id_user );

        [OperationContract]
        UserVM GetUserLogin( string login );

        [OperationContract]
        List<UserVM> GetUsersClient( int id_client );

        [OperationContract]
        List<UserVM> GetUsers( int id_client, bool active );
        #endregion

        #region Clients
        [OperationContract]
        void CreateClient( ClientVM client );

        [OperationContract]
        void UpdateClient( ClientVM client );

        [OperationContract]
        void ActivateClient( int id_client );

        [OperationContract]
        List<ClientVM> GetClients( bool active );


        #endregion

        #region Patients

        #endregion

        #region Odontogram

        [OperationContract]
        void CreateOdontogram( int id_patient );

        [OperationContract]
        OdontogramVM GetOdontogram( int id_patient, bool first );

        [OperationContract]
        void UpdateOdontogram( int id_patient );


        #endregion

        #region OdontogramAction
        [OperationContract]
        List<OdontogramActionVM> GetOdontogramActions( );

        #endregion

        #region OdontogramTreatment
        [OperationContract]
        List<OdontogramTreatmentVM> GetOdontogramTreatments( );

        
        #endregion

        #region Service
        #endregion

        #region Appointment
        #endregion

        #region StateAppointment
        #endregion


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

}
