#include <bits/stdc++.h>
using namespace std;

const int MOD = 10000007;

int main() {
    // Precompute factorial sum up to MOD-1
    vector<int> fact_sum(MOD);

    long long f = 1;
    fact_sum[0] = 1; // 0! = 1
    
    for (int i = 1; i < MOD; i++) {
        f = (f * i) % MOD;
        fact_sum[i] = (fact_sum[i-1] + f) % MOD;
    }

    int t;
    cin >> t;
    while (t--) {
        long long n;
        cin >> n;

        if (n >= MOD) n = MOD-1; // all larger factorials are 0 mod MOD
        cout << fact_sum[n] << endl;
    }

    return 0;
}
