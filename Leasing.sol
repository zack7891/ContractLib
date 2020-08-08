pragma solidity >=0.6.9 <0.8.0;

contract AssetTransferContract{
    address payable public seller;
    address payable public buyer;
    uint256 public expiration;
    uint public ownership;
    
    constructor(address payable _seller, uint256 duration, uint _ownership) public payable
    {
        buyer = msg.sender;
        seller = _seller;
        expiration = block.timestamp + duration;
        ownership = _ownership;
    }

    function close(uint256 amount, bytes memory signature) public
    {
       require(msg.sender == buyer);
       require(isValidSignature(amount, signature));

       buyer.transfer(amount);
       selfdestruct(seller);

    }

    function extend(uint256 newExpiration) public{
        require(msg.sender == seller);
        require(newExpiration > expiration);

        expiration = newExpiration;
    }

    function claimTimeout() public{
        require(block.timestamp >= expiration);
        selfdestruct(seller);
    }

    function isValidSignature(uint256 amount, bytes memory signature)
    internal
    view
    returns (bool){
        bytes32 message = prefixed(keccak256(abi.encodePacked(this, amount)));

        return recoverSigner(message, signature) == seller;
    }
    function splitSignature(bytes memory sig)
        internal
        pure
        returns (uint8 v, bytes32 r, bytes32 s)
    {
        require(sig.length == 65);

        assembly {
            // first 32 bytes, after the length prefix
            r := mload(add(sig, 32))
            // second 32 bytes
            s := mload(add(sig, 64))
            // final byte (first byte of the next 32 bytes)
            v := byte(0, mload(add(sig, 96)))
        }

        return (v, r, s);
    }

    function recoverSigner(bytes32 message, bytes memory sig)
        internal
        pure
        returns (address)
    {
        (uint8 v, bytes32 r, bytes32 s) = splitSignature(sig);

        return ecrecover(message, v, r, s);
    }

    /// builds a prefixed hash to mimic the behavior of eth_sign.
    function prefixed(bytes32 hash) internal pure returns (bytes32) {
        return keccak256(abi.encodePacked("\x19Ethereum Signed Message:\n32", hash));
    }
}