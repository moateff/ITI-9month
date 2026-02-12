#include <iostream>
#include <vector>
using namespace std;

int knapsack(int capicity, vector<int>& W, vector<int>& V) {
    int n = W.size();

    vector<vector<int>> dp(n + 1, vector<int>(capicity + 1, 0));

    for (int i = 1; i <= n; i++) {
        // current item
        int w = W[i - 1], v = V[i - 1];

        for (int j = 1; j <= capicity; j++) {
            // do not take
            dp[i][j] = dp[i - 1][j];

            // take
            if (j >= w && dp[i - 1][j - w] + v > dp[i][j]) {
                dp[i][j] = dp[i - 1][j - w] + v;
            }
        }
    }

    /*
    vector<int> itemSelected;
    int j = capicity;
    for (int i = n; i > 0; i--) {
        if (dp[i][j] != dp[i - 1][j]) {
            itemSelected.push_back(i - 1);
            j -= W[i - 1];
        }
    }
    reverse(itemSelected.begin(), itemSelected.end());
    */

    return dp[n][capicity];
}

int main() {
    int capicity = 7;
    vector<int> weight = {3, 1, 3, 4, 2};
    vector<int> value = {2, 2, 4, 5, 3};

    cout << knapsack(capicity, weight, value) << endl;
    return 0;
}