using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using ContractLib.AssetTransferContract.ContractDefinition;

namespace ContractLib.AssetTransferContract
{
    public partial class AssetTransferContractService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AssetTransferContractDeployment assetTransferContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetTransferContractDeployment>().SendRequestAndWaitForReceiptAsync(assetTransferContractDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AssetTransferContractDeployment assetTransferContractDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetTransferContractDeployment>().SendRequestAsync(assetTransferContractDeployment);
        }

        public static async Task<AssetTransferContractService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AssetTransferContractDeployment assetTransferContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, assetTransferContractDeployment, cancellationTokenSource);
            return new AssetTransferContractService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AssetTransferContractService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BuyerQueryAsync(BuyerFunction buyerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyerFunction, string>(buyerFunction, blockParameter);
        }

        
        public Task<string> BuyerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyerFunction, string>(null, blockParameter);
        }

        public Task<string> ClaimTimeoutRequestAsync(ClaimTimeoutFunction claimTimeoutFunction)
        {
             return ContractHandler.SendRequestAsync(claimTimeoutFunction);
        }

        public Task<string> ClaimTimeoutRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ClaimTimeoutFunction>();
        }

        public Task<TransactionReceipt> ClaimTimeoutRequestAndWaitForReceiptAsync(ClaimTimeoutFunction claimTimeoutFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimTimeoutFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ClaimTimeoutRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ClaimTimeoutFunction>(null, cancellationToken);
        }

        public Task<string> CloseRequestAsync(CloseFunction closeFunction)
        {
             return ContractHandler.SendRequestAsync(closeFunction);
        }

        public Task<TransactionReceipt> CloseRequestAndWaitForReceiptAsync(CloseFunction closeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(closeFunction, cancellationToken);
        }

        public Task<string> CloseRequestAsync(BigInteger amount, byte[] signature)
        {
            var closeFunction = new CloseFunction();
                closeFunction.Amount = amount;
                closeFunction.Signature = signature;
            
             return ContractHandler.SendRequestAsync(closeFunction);
        }

        public Task<TransactionReceipt> CloseRequestAndWaitForReceiptAsync(BigInteger amount, byte[] signature, CancellationTokenSource cancellationToken = null)
        {
            var closeFunction = new CloseFunction();
                closeFunction.Amount = amount;
                closeFunction.Signature = signature;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(closeFunction, cancellationToken);
        }

        public Task<BigInteger> ExpirationQueryAsync(ExpirationFunction expirationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ExpirationFunction, BigInteger>(expirationFunction, blockParameter);
        }

        
        public Task<BigInteger> ExpirationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ExpirationFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ExtendRequestAsync(ExtendFunction extendFunction)
        {
             return ContractHandler.SendRequestAsync(extendFunction);
        }

        public Task<TransactionReceipt> ExtendRequestAndWaitForReceiptAsync(ExtendFunction extendFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(extendFunction, cancellationToken);
        }

        public Task<string> ExtendRequestAsync(BigInteger newExpiration)
        {
            var extendFunction = new ExtendFunction();
                extendFunction.NewExpiration = newExpiration;
            
             return ContractHandler.SendRequestAsync(extendFunction);
        }

        public Task<TransactionReceipt> ExtendRequestAndWaitForReceiptAsync(BigInteger newExpiration, CancellationTokenSource cancellationToken = null)
        {
            var extendFunction = new ExtendFunction();
                extendFunction.NewExpiration = newExpiration;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(extendFunction, cancellationToken);
        }

        public Task<BigInteger> OwnershipQueryAsync(OwnershipFunction ownershipFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnershipFunction, BigInteger>(ownershipFunction, blockParameter);
        }

        
        public Task<BigInteger> OwnershipQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnershipFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SellerQueryAsync(SellerFunction sellerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerFunction, string>(sellerFunction, blockParameter);
        }

        
        public Task<string> SellerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerFunction, string>(null, blockParameter);
        }
    }
}
