              --------------------------------
             |        <<abstract>>            |
             |            Shape               |
              --------------------------------
             | - (hidden attributes)          |
             | + (hidden methods)             |
              --------------------------------
                       /              \      \
                      /                \       \
                     /                  \        \
      ----------------------------       
     |         Circle             |     Rectangle    Polygon
      ----------------------------      (hidden)      (hidden)
     | - radius: float            |
     | - center: Point            |
     |----------------------------|
     | + area(): double           |
     | + circum(): double         |
     | + setCenter(c:Point): void |
     | + setRadius(r:float): void |
      ----------------------------


   Circle "owns" Point
   -------------------
   | Point          |
   | - x: float     |
   | - y: float     |
   -------------------

   Window "contains" Shape
   --------------------------------
   | Window                        |
   | - (hidden attributes)         |
   | + (hidden methods)            |
   --------------------------------

   Window *—•* Shape
   (Shapes can exist without Window)

   Window depends on Event
   ----------------------
   | Event                       |
   | - (hidden attributes)       |
   | + (hidden methods)          |
   ------------------------------

   Window -- (uses) --> Event
