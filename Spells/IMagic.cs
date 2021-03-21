using System;
using System.Collections.Generic;
using System.Text;

namespace GameKash {
    interface IMagic {
        void MagicCast(Character character, double power) {
            
        }
        void MagicCast(double power) {

        }
        void MagicCast(Character character) {

        }
        void MagicCast() {

        }
    }
}
