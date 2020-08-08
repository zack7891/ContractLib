using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace ContractLib.AssetTransferContract.ContractDefinition
{


    public partial class AssetTransferContractDeployment : AssetTransferContractDeploymentBase
    {
        public AssetTransferContractDeployment() : base(BYTECODE) { }
        public AssetTransferContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class AssetTransferContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526040516104bb3803806104bb8339818101604052606081101561002657600080fd5b5080516020820151604090920151600180546001600160a01b03199081163317909155600080546001600160a01b0390941693909116929092179091554290910160025560035561043f8061007c6000396000f3fe608060405234801561001057600080fd5b506004361061007d5760003560e01c80634665096d1161005b5780634665096d1461015d5780635d03147a146101775780637150d8ae1461017f5780639714378c146101875761007d565b806308551a53146100825780630e1da6c3146100a6578063415ffba7146100b0575b600080fd5b61008a6101a4565b604080516001600160a01b039092168252519081900360200190f35b6100ae6101b3565b005b6100ae600480360360408110156100c657600080fd5b813591908101906040810160208201356401000000008111156100e857600080fd5b8201836020820111156100fa57600080fd5b8035906020019184600183028401116401000000008311171561011c57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295506101d0945050505050565b610165610243565b60408051918252519081900360200190f35b610165610249565b61008a61024f565b6100ae6004803603602081101561019d57600080fd5b503561025e565b6000546001600160a01b031681565b6002544210156101c257600080fd5b6000546001600160a01b0316ff5b6001546001600160a01b031633146101e757600080fd5b6101f18282610288565b6101fa57600080fd5b6001546040516001600160a01b039091169083156108fc029084906000818181858888f19350505050158015610234573d6000803e3d6000fd5b506000546001600160a01b0316ff5b60025481565b60035481565b6001546001600160a01b031681565b6000546001600160a01b0316331461027557600080fd5b600254811161028357600080fd5b600255565b6000806102d7308560405160200180836001600160a01b03166001600160a01b031660601b81526014018281526020019250505060405160208183030381529060405280519060200120610302565b6000549091506001600160a01b03166102f08285610353565b6001600160a01b031614949350505050565b604080517f19457468657265756d205369676e6564204d6573736167653a0a333200000000602080830191909152603c8083019490945282518083039094018452605c909101909152815191012090565b600080600080610362856103da565b92509250925060018684848460405160008152602001604052604051808581526020018460ff1660ff1681526020018381526020018281526020019450505050506020604051602081039080840390855afa1580156103c5573d6000803e3d6000fd5b5050604051601f190151979650505050505050565b600080600083516041146103ed57600080fd5b5050506020810151604082015160609092015160001a9290919056fea26469706673582212202651e89bb0369cc3bfb1267652e26b2a4468f5824cbb08a0a3c063f96a3e33ef64736f6c63430006090033";
        public AssetTransferContractDeploymentBase() : base(BYTECODE) { }
        public AssetTransferContractDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_seller", 1)]
        public virtual string Seller { get; set; }
        [Parameter("uint256", "duration", 2)]
        public virtual BigInteger Duration { get; set; }
        [Parameter("uint256", "_ownership", 3)]
        public virtual BigInteger Ownership { get; set; }
    }

    public partial class BuyerFunction : BuyerFunctionBase { }

    [Function("buyer", "address")]
    public class BuyerFunctionBase : FunctionMessage
    {

    }

    public partial class ClaimTimeoutFunction : ClaimTimeoutFunctionBase { }

    [Function("claimTimeout")]
    public class ClaimTimeoutFunctionBase : FunctionMessage
    {

    }

    public partial class CloseFunction : CloseFunctionBase { }

    [Function("close")]
    public class CloseFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "signature", 2)]
        public virtual byte[] Signature { get; set; }
    }

    public partial class ExpirationFunction : ExpirationFunctionBase { }

    [Function("expiration", "uint256")]
    public class ExpirationFunctionBase : FunctionMessage
    {

    }

    public partial class ExtendFunction : ExtendFunctionBase { }

    [Function("extend")]
    public class ExtendFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newExpiration", 1)]
        public virtual BigInteger NewExpiration { get; set; }
    }

    public partial class OwnershipFunction : OwnershipFunctionBase { }

    [Function("ownership", "uint256")]
    public class OwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SellerFunction : SellerFunctionBase { }

    [Function("seller", "address")]
    public class SellerFunctionBase : FunctionMessage
    {

    }

    public partial class BuyerOutputDTO : BuyerOutputDTOBase { }

    [FunctionOutput]
    public class BuyerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class ExpirationOutputDTO : ExpirationOutputDTOBase { }

    [FunctionOutput]
    public class ExpirationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class OwnershipOutputDTO : OwnershipOutputDTOBase { }

    [FunctionOutput]
    public class OwnershipOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SellerOutputDTO : SellerOutputDTOBase { }

    [FunctionOutput]
    public class SellerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
