#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    long long t;
    cin >> n >> t;

    vector<int> a(n);
    for (int i = 0; i < n; i++)
        cin >> a[i];

    int l = 0;
    long long sum = 0;
    int ans = 0;

    for (int r = 0; r < n; r++) {
        sum += a[r];

        while (sum > t) {
            sum -= a[l];
            l++;
        }

        ans = max(ans, r - l + 1);
    }

    cout << ans << endl;
    return 0;
}