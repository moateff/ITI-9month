#include <iostream>
#include <map>
using namespace std;

int main() {
    int n;
    cin >> n;

    map<int, int> freq;
    for (int i = 0; i < n; i++) {
        int x;
        cin >> x;
        freq[x]++;
    }

    int maxPockets = 0;
    for (auto &p : freq) {
        maxPockets = max(maxPockets, p.second);
    }

    cout << maxPockets << endl;
    return 0;
}

/*
#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> coins(n);
    for (int i = 0; i < n; i++) {
        cin >> coins[i];
    }

    // Each pocket is a vector of coin values
    vector<vector<int>> pockets;

    for (int coin : coins) {
        bool placed = false;

        // Try to place the coin in an existing pocket
        for (auto &pocket : pockets) {
            bool exists = false;

            for (int x : pocket) {
                if (x == coin) {
                    exists = true;
                    break;
                }
            }

            if (!exists) {
                pocket.push_back(coin);
                placed = true;
                break;
            }
        }

        // If the coin couldn't be placed, create a new pocket
        if (!placed) {
            pockets.push_back({coin});
        }
    }

    cout << pockets.size() << endl;
    return 0;
}
*/