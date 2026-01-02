export class BankAccount {
    constructor(accountHolder, balance) {
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    deposit(amount) {
        if (amount > 0) {
            this.balance += amount;
        }
    }

    withdraw(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
        }
    }

    static info() {
        return "Bank System v1.0";
    }
}
