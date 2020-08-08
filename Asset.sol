pragma solidity ^0.6.9;

///@title OurHome
///@author Zbaker

contract OurHome{

    mapping (address => uint) private balances;

    address public owner;
    
    event LogDepositMade(address accountAddress, uint amount);

    constructor(OurHome) public{
        owner = msg.sender;

    }

    function deposit() public payable returns(uint){
        require((balances[msg.sender]+msg.value) >= balances[msg.sender]);
      
        balances[msg.sender] += msg.value;

        emit LogDepositMade(msg.sender, msg.value);

        return balances[msg.sender];
    }
   
   
    function withdraw(uint withdrawAmount) public returns (uint remainingBal) {
        require(withdrawAmount <= balances[msg.sender]);

        balances[msg.sender] -= withdrawAmount;

        // this automatically throws on a failure, which means the updated balance is reverted
        msg.sender.transfer(withdrawAmount);

        return balances[msg.sender];
    }
    /// @notice Get balance
    /// @return The balance of the user
    // 'view' (ex: constant) prevents function from editing state variables;
    // allows function to run locally/off blockchain
    function balance() view public returns (uint) {
        return balances[msg.sender];
    }
}
