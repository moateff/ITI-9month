#include <bits/stdc++.h>
using namespace std;

int main() {
    int t;
    cin >> t;

    while (t--) {
        int n;
        long long len;
        cin >> n >> len;

        vector<long long> a(n);
        for (int i = 0; i < n; i++) cin >> a[i];

        deque<int> min, max;   // store indices
        int l = 0;
        int ans = 0;

        for (int r = 0; r < n; r++) {

            // maintain min deque
            while (!min.empty() && a[min.back()] >= a[r])
                min.pop_back();
            min.push_back(r);

            // maintain max deque
            while (!max.empty() && a[max.back()] <= a[r])
                max.pop_back();
            max.push_back(r);

            // shrink window if invalid
            while (!min.empty() && !max.empty() &&
                   a[max.front()] - a[min.front()] > len) {

                if (min.front() == l) min.pop_front();
                if (max.front() == l) max.pop_front();
                l++;
            }

            ans = std::max(ans, r - l + 1);
        }

        cout << ans << endl;
    }
    return 0;
}
