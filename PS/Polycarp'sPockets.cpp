#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n;
    vector<int> a;
    int ai;

    cin >> n;
    for (int i = 0; i < n; i++) {
        cin >> ai;
        a.push_back(ai);
    }
    
    bool found;
    vector<vector<int>> packets;

    for (auto& ai : a) {
        for (auto& packet : packets) {
            found = false;
            for (auto& coin : packet) {
                if (ai == coin) {
                    found = true;
                    break;
                }
            }
            if (found) continue;
            else {
                packet.push_back(ai);
                break;
            }
        }
        if (packets.empty()) {
            vector<int> packet = {ai};
            packets.push_back(packet);
        } else {
            if (found) {
                vector<int> packet = {ai};
                packets.push_back(packet);
            }
        }
    }

    cout << packets.size() << endl;

    return 0;
}