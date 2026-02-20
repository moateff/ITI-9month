#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    cin >> n;

    string s;
    cin >> s;

    set<char> st;
    for (int i = 0; i < n; i++) 
        st.insert(s[i]);
    int distinct = (int)st.size();

    unordered_map<char, int> mp;
    int distinct_curr = 0;

    int min_len = n;
    int l = 0;

    for (int r = 0; r < n; r++) {
        if (mp[s[r]] == 0) 
            distinct_curr++;
        mp[s[r]]++;

        // shrink while window still contains all distinct characters
        while (distinct_curr == distinct && mp[s[l]] > 1) {
            mp[s[l]]--;
            l++;
        }

        if (distinct_curr == distinct) {
            min_len = min(min_len, r - l + 1);
        }
    }
    cout << min_len << endl;

    return 0;
}