using Observer.Class;

MessageSubscriberOne s1 = new MessageSubscriberOne();
MessageSubscriberTwo s2 = new MessageSubscriberTwo();
         
MessagePublisher p = new MessagePublisher();
         
p.attach(s1);
p.attach(s2);
String message = "First Message";         
p.notifyUpdate(message);   
         
p.detach(s1);
message = "Second Message";     
p.notifyUpdate(message); 