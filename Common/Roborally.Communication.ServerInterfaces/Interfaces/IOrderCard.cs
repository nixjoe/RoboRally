namespace Roborally.Communication.ServerInterfaces
{
    /// <summary>The OrderCard interface.</summary>
    public interface IOrderCard
    {
        #region Public Properties

        /// <summary>Gets the card identifier (in scope of turn).</summary>
        string ID { get; }
        
        /// <summary>Gets the energy.</summary>
        int Energy { get; }

        /// <summary>Gets the speed.</summary>
        int Speed { get; }

        /// <summary>Gets the type.</summary>
        MoveDirectionEnum Type { get; }

        #endregion
    }
}