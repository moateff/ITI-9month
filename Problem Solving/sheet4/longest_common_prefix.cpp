#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

class Solution {
public:
    string longestCommonPrefix(vector<string>& strs) {
        int size = strs.size();

        int min = (*min_element(strs.begin(), strs.end(), [](const string& a, const string& b) 
                        { return a.size() < b.size(); })).size();
        
        bool mismatch = false; 
        string ans = "";

        for (int i = 0; i < min; i++) {
            char ch = strs[0][i];

            for (int j = 1; j < size; j++) {
                if (ch != strs[j][i]) {
                    mismatch = true;
                    break;
                }
            }

            if (mismatch) break;
            ans += ch;
        }

        return ans;
    }
};

int main() {
    Solution solution;

    vector<string> strs;

    strs = {"flower", "flow", "flight"};
    cout << solution.longestCommonPrefix(strs) << endl;

    strs = {"flower"};
    cout << solution.longestCommonPrefix(strs) << endl;

    return 0;
}