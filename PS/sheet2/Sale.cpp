#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
    int n, m;
    cin >> n >> m;

    vector<int> prices(n);
    for (int i = 0; i < n; i++) {
        cin >> prices[i];
    }

    // Sort prices in ascending order
    sort(prices.begin(), prices.end());

    int earnings = 0;
    // Take up to m most negative prices
    for (int i = 0; i < m; i++) {
        if (prices[i] < 0) {
            earnings += -prices[i]; // negative price means money earned
        } else {
            break; // all remaining prices are non-negative
        }
    }

    cout << earnings << endl;

    return 0;
}
