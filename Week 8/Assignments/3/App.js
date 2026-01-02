import { BankAccount } from "./Account";

// Create two separate accounts
const user1 = new BankAccount("Dharmik", 1000);
const user2 = new BankAccount("John", 50000);

// Perform transactions
user1.deposit(200);
user1.withdraw(150);

user2.deposit(300);
user2.withdraw(100);

// Verify balances do not interfere
console.log(user1.accountHolder, user1.balance);
console.log(user2.accountHolder, user2.balance);

// Static method
console.log(BankAccount.info());
