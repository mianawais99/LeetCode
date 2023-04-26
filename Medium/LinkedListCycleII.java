/**
 * Definition for singly-linked list.
 * class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode detectCycle(ListNode head) {

        ListNode turtle =head;
        ListNode rabbit =head;
        boolean cycle= false;
        while(rabbit!=null && rabbit.next!= null){
            turtle= turtle.next;
            rabbit= rabbit.next.next;
            if(turtle == rabbit){    // cycle is detected
                turtle= head;
                while(turtle!=rabbit){
                    turtle = turtle.next;
                    rabbit = rabbit.next;
                }
                return turtle;    
            }
        }
        return null;  //no cycle detected
        
    }
}