namespace Roborally.Server.Photon
{
    using EmitMapper;

    using global::Photon.SocketServer;

    using Roborally.Communication.Data.DataContracts;
    using Roborally.Communication.ServerInterfaces;


    /// <summary>The main peer.</summary>
    public partial class MainPeer
    {
        /// <summary>The on operation request.</summary>
        /// <param name="operationRequest">The operation request.</param>
        /// <param name="sendParameters">The send parameters.</param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch (operationRequest.OperationCode)
            {
                case LoginParameters.OperationCode:
                    this.Login(operationRequest, sendParameters);
                    break;
                default:
                    break;
            }
        }

        private void Login(OperationRequest operationRequest, SendParameters sendParameters)
        {
            var incoming = new LoginParameters(operationRequest.Parameters);
            var user = this.mainService.Login(incoming.Login, incoming.Password);

            PhotonUser photonUser;
            if (user != null)
            {
                photonUser = ObjectMapperManager.DefaultInstance.GetMapper<IUser, PhotonUser>().Map(user);
            }
            else
            {
                photonUser = new PhotonUser() { ID = "0", Name = string.Empty };
            }

            var response = new OperationResponse(operationRequest.OperationCode, photonUser.ToParameters());
            this.SendOperationResponse(response, sendParameters);
        }
    }
}