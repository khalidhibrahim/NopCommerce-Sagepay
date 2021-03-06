using System;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Payments.SagePayServer.Core.Domain;

namespace Nop.Plugin.Payments.SagePayServer.Services
{
    /// <summary>
    /// Order service
    /// </summary>
    public partial class SagePayServerTransactionService : ISagePayServerTransactionService
    {
        #region Fields

        private readonly IRepository<SagePayServerTransaction> _sagePayServerTransactionRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="sagePayServerTransactionRepository">SagePay Server Transaction repository</param>
        public SagePayServerTransactionService(IRepository<SagePayServerTransaction> sagePayServerTransactionRepository)
        {
            this._sagePayServerTransactionRepository = sagePayServerTransactionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a SagePay Server Transaction
        /// </summary>
        /// <param name="vendorTxCode">The vendor transcation code</param>
        /// <returns>SagePayServerTransaction</returns>
        public virtual SagePayServerTransaction GetSagePayServerTransactionByVendorTxCode(string vendorTxCode)
        {
            if (vendorTxCode == String.Empty)
                return null;

            return _sagePayServerTransactionRepository.Table
                .FirstOrDefault(x => x.VendorTxCode.ToUpper() == vendorTxCode.ToUpper());
        }

        /// <summary>
        /// Inserts a SagePay Server Transaction
        /// </summary>
        /// <param name="sagePayServerTransaction">SagePay Server Transaction</param>
        public virtual void InsertSagePayServerTransaction(SagePayServerTransaction sagePayServerTransaction)
        {
            if (sagePayServerTransaction == null)
                throw new ArgumentNullException("sagePayServerTransaction");

            _sagePayServerTransactionRepository.Insert(sagePayServerTransaction);
        }

        /// <summary>
        /// Updates the SagePay Server Transaction
        /// </summary>
        /// <param name="sagePayServerTransaction">The SagePay Server Transaction</param>
        public virtual void UpdateSagePayServerTransaction(SagePayServerTransaction sagePayServerTransaction)
        {
            if (sagePayServerTransaction == null)
                throw new ArgumentNullException("sagePayServerTransaction");

            _sagePayServerTransactionRepository.Update(sagePayServerTransaction);
        }
        
        #endregion
    }
}
