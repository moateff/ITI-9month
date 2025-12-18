#include <iostream>
using namespace std;

// Strategy Interface
class PaymentStrategy {
public:
    virtual void pay(int amount) const = 0;
    virtual ~PaymentStrategy() = default;
};

// Concrete Strategy 1
class CreditCardPayment : public PaymentStrategy {
public:
    void pay(int amount) const override {
        cout << "Paid " << amount << " using Credit Card" << endl;
    }
};

// Concrete Strategy 2
class PayPalPayment : public PaymentStrategy {
public:
    void pay(int amount) const override {
        cout << "Paid " << amount << " using PayPal" << endl;
    }
};

// Concrete Strategy 3
class CashPayment : public PaymentStrategy {
public:
    void pay(int amount) const override {
        cout << "Paid " << amount << " using Cash" << endl;
    }
};

// Context
class ShoppingCart {
private:
    PaymentStrategy* strategy;   // raw pointer (non-owning until set)

public:
    ShoppingCart() : strategy(nullptr) {}

    void setPaymentStrategy(PaymentStrategy* s) {
        strategy = s;
    }

    void checkout(int amount) const {
        if (!strategy)
            throw runtime_error("Payment strategy not set");
        strategy->pay(amount);
    }
};

int main() {
    ShoppingCart cart;

    CreditCardPayment card;
    PayPalPayment paypal;
    CashPayment cash;

    cart.setPaymentStrategy(&card);
    cart.checkout(500);

    cart.setPaymentStrategy(&paypal);
    cart.checkout(300);

    cart.setPaymentStrategy(&cash);
    cart.checkout(100);

    return 0;
}
