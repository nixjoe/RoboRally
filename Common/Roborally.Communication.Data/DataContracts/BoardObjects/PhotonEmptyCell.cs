﻿using System.Runtime.Serialization;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts.BoardObjects
{
    /// <summary>The photon empty cell.</summary>
    [DataContract]
    public class PhotonEmptyCell : IEmptyCell
    {
        /// <summary>Gets the position.</summary>
        [DataMember]
        public IPosition Position { get; set; }
    }
}
