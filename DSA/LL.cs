// Program to create a Linked List class with 3 nodes
using System;
using System.Collections.Generic;
public class LinkedList{
    public Node head;
    public class Node{
        public Node next;
        public int data;
        public bool visitedAgain=false;
        public Node(int d)
        {
            data=d;
        }
    }

    public void PrintList(){
        int length=0;
        Node n= head;
        while(n != null)
        {
            length++;
            Console.WriteLine(n.data);
            n= n.next;
        }
        Console.WriteLine("Length of the Linked List:"+ length);
    }
    public int LengthThroughRec(Node m)
    {
        if(m==null)
        return 0;
        else
        return 1 + Convert.ToInt16(LengthThroughRec(m.next));
    }
    public Node AddNodeAtLast(int Val)
    {
        //Check if linked list is empty
        Node n=head;
        Node m=new Node(Val);
        if(n == null)
        {
            head = m;
            m.next=null;
        }
        else{
        while(n.next != null ){
            n=n.next;
        }
        n.next=m;
        m.next=null;
        }
        return head;
    }

    public Node AddNodeAtStart(Node head, int Val)
    {
        Node newNode=new Node(Val);
        Node curr=head;
        if(curr==null)
        {
            head=newNode;
            newNode.next=null;
            return head;
        }
        else{
            newNode.next=head;
            head=newNode;
        }
        return head;
    }
    public void AddNodeAfterGivenNode(int givenVal, int val)
    {
        Node n =head;
        Node givenNode=new Node(givenVal);
        if(n == null)
        {
            head = givenNode;
            givenNode.next=null;
        }
        else{
            while(n.next.data !=val)
            {
                n=n.next;
            }

            givenNode.next=n.next.next;
            n.next.next=givenNode;
        }
    }
    public Node InsertNodeAtPosition(Node llist, int data, int position)
    {
        Node curr=llist;
        Node newNode=new Node(data);
        Node prev=null;
        int count=0;
        if(position==0 && llist==null)
        {
            llist=newNode;
            newNode.next=null;          
        }
        else 
        {
            while(curr!=null)
            {
                if(position==count && prev==null)
                {
                    newNode.next=curr;
                    llist=newNode;
                    break;
                }
                if(position==count && prev!=null)
                {
                   prev.next=newNode;
                   newNode.next=curr;
                   break;
                }
                if(curr.next==null){
                    curr.next=newNode;
                    newNode.next=null;
                    break;
                }
                
                prev=curr;
                curr=curr.next;
                count++;
            }
        }
        return llist;
    }
    public void DeleteANodeWithGivenKey(int val)
    {
        Node predecessorNode=head;
        if(predecessorNode==null)
        {
            Console.WriteLine("Cant delete the node as the Linked List is empty");
        }
        else if (head.data == val)
        {
            predecessorNode=head;
            head=head.next;
            predecessorNode=null;
        }
        else{
            while(predecessorNode.next.data != val)
            {
                predecessorNode=predecessorNode.next;
            }
            Node tobeDeleted=predecessorNode.next;
            Node successorNode=tobeDeleted.next;
            predecessorNode.next=successorNode;
            tobeDeleted=null;            
        }
    }
    public void DeleteNodeAtPosition(int position)
    {
        Node n=head;
        //int currentPosition=0;
        Node predNode=null;
        if(position == 0)
        {
            head=head.next;
        }
        else 
        {
            for(int currentPosition=0;currentPosition < position-1 && n !=null; currentPosition++)
            {
                n=n.next;
            }
            if(n.next == null)
            {
                return;
            }
            else if (n==null)
            {
                return;
            }
            predNode=n;
            Node nextNode=n.next.next;
            n.next=nextNode;
        }
    }
    public void SwapPositionsOfTheseNumbers(int x, int y)
    {
        Node n=head;
        bool xPres=false;
        bool yPres=false;
        Node xPos=null;
        Node yPos=null;
        Node xPrev=null;
        Node yPrev=null;
        if(x == y)
        {
            return;
        }
        if(n.data==y)
        {
            int temp=x;
            x=y;
            y=temp;
        }
        if(n.data==x)
        {
            xPres=true;
            xPos=n;
        }
        

        while(n!=null && (!xPres || !yPres))
        {        
            if(n.next.data == x && !xPres)
            {
                xPres=true;
                xPos=n.next;
                xPrev=n;
            }
             if(n.next.data == y && !yPres)
            {
                yPres=true;
                yPos=n.next;
                yPrev= n;
            }
            n=n.next;
        }
        if(xPres && yPres)
        {            
        if (xPrev != null)
            xPrev.next = yPos;
        else // make y the new head
            head = yPos;
 
        // If y is not head of linked list
        if (yPrev != null)
            yPrev.next = xPos;
        else // make x the new head
            head = xPos;
 
        // Swap next pointers
        Node temp = xPos.next;
        xPos.next = yPos.next;
        yPos.next = temp;
        }
        else
        return;

    }
    public void ReverseList()
    {
     Node prev=null;
     Node curr=head;
     Node next=null;
     while(curr != null)
     {
        next=curr.next;
        curr.next=prev;
        prev=curr;
        curr=next;
     }
        head=prev;
    }
    public Node ReverseByGroupSize(Node h, int k)
    {
        if(h==null)
        {
            return null;
        }
        Node curr=h;
        Node prev=null;
        Node next=null;
        int count=0;
        while(count<k && curr!=null)
        {
            next=curr.next;
            curr.next=prev;
            prev=curr;
            curr=next;
            count++;
        }
        if(next!=null)
        {
            h.next = ReverseByGroupSize(next, k);
        }
        return prev;
    }
    
    public Node MergeSortedLists(Node firstList, Node secondList)
    {
        Node dummyNode=new Node(0);
        Node tail= dummyNode;
        while(true)
        {
            if(firstList==null){
                tail.next= secondList;
                break;
            }
            if(secondList==null){
                tail.next=firstList;
                break;
            }
            if(firstList.data<=secondList.data)
            {
                tail.next= firstList;
                firstList=firstList.next;
            }
            else{
                tail.next=secondList;
                secondList=secondList.next;
            }
            tail=tail.next;
        }
        return dummyNode.next;

    }
    public Node MergeSort(Node a, Node b)
    {
        if(a==null)
        return b;
        if(b==null)
        return a;
        Node result=null;
        if(a.data<=b.data)
        {
            result=a;
            result.next=MergeSort(a.next,b);
        }
        else
        {
            result=b;
            result.next=MergeSort(a,b.next);
        }
        return result;
    }
    public Node MergeDivide(Node m){
        if(m==null || m.next==null)
            return m;
        Node middle=getMiddle(m);
        Node middlenext=middle.next;
        middle.next=null;
        Node a=MergeDivide(m);
        Node b=MergeDivide(middlenext);
        Node result=MergeSortedLists(a, b);
        return result;
    }
    public Node getMiddle(Node n)
    {
        if(n==null)
            return n;
        Node fastptr=n.next;
        Node slowptr=n;
        while(fastptr!=null)
        {
            fastptr=fastptr.next;
            if(fastptr!=null)
            {
                fastptr=fastptr.next;
                slowptr=slowptr.next;
            }
        }
        return slowptr;
    }
    public int NoOfNodesInCaseOfLoop()
    {
       Node curr=head;
       int count=0;
       while(!curr.visitedAgain){
        curr.visitedAgain=true;
        curr=curr.next;
        count++;
       }
       return count;
    }
    public Node RemoveLoop(int count)
    {
        Node dummyNode=new Node(0);
        Node tail= dummyNode;
        Node m=head;
        while(count!=0)
        {
            tail.next=m;
            m=m.next;
            tail=tail.next; 
            count--;  
        } 
        tail.next=null;
        return dummyNode.next;
    }
    public Node AddNumbersByLinkedList(Node list1, Node list2)
    {
        Node currList1 = list1;
        Node currList2 = list2;
        int list1Count=-1;
        int list2Count=-1;
        while(currList1!=null)
        {
            list1Count++;
            currList1=currList1.next;
        }
        while(currList2 != null)
        {
            list2Count++;
            currList2=currList2.next;
        }
        int firstdigitList1=list1.data;
        int firstdigitList2=list2.data;
        int number1=0;
        int number2=0;
        while(list1Count!=0 && list1!=null)
        {
            number1 += firstdigitList1 * Convert.ToInt32(Math.Pow(10,list1Count));
            list1=list1.next;
            firstdigitList1=list1.data;
            list1Count--;
        }
        number1+=firstdigitList1 * Convert.ToInt32(Math.Pow(10,list1Count));
        while(list2Count!=0 && list2!=null)
        {
            number2 += firstdigitList2 * Convert.ToInt32(Math.Pow(10, list2Count));
            list2=list2.next;
            firstdigitList2=list2.data;
            list2Count--;
        }
        number2+=firstdigitList2*Convert.ToInt32(Math.Pow(10,list2Count));
        int sum=number1 + number2;
        Console.WriteLine(sum);
        Node dummy=new Node(100);
        Node tail=dummy;
        int sumCount=Convert.ToInt32(Math.Floor(Math.Log10(sum) + 1));
        while(sumCount!=0)
        {
            sumCount--;
            tail.next=new Node(sum/Convert.ToInt32(Math.Pow(10,sumCount)));
            tail=tail.next;
            sum=sum % Convert.ToInt32(Math.Pow(10,sumCount));
        }
        return dummy.next;
    }
    public Node RotateLinkedList(int k)
    {
        Node curr=head;
        Node prev=null;
        Node dummyNode=new Node(0);
        Node tail=dummyNode;
        Node x=head;
        int count=0;
        while(x!=null)
        {
            count++;
            x=x.next;
        }
        if(k>=count)
        return curr;
        while(k>0)
        {
            tail.next=new Node(curr.data);
            k--;
            tail=tail.next;
            prev=curr;
            curr=curr.next;
        }
        prev=null;
        Node nextEl=new Node(0);
        nextEl.next=curr;
        while(curr.next!=null)
        {
            curr=curr.next;
        }
        curr.next=dummyNode.next;       
        return nextEl.next;       
    }
    public void SearchListForGivenKey(int key)
    {
        Node curr=head;
        bool keyFound=false;
        int pos=1;
        while(curr!=null)
        {
            if(curr.data==key)
            {
                keyFound=true;
                break;
            }
            curr=curr.next;
            pos++;
        }
        if(keyFound)
            Console.WriteLine("Key found at position: "+pos);
        else
            Console.WriteLine("Key could not be found");
    }
    public void SearchListRecursively(Node m, int key, int pos)
    {
        Node curr=m;
        if(curr==null)
        {
            Console.WriteLine("Sorry Mario!. Your princess is in another castle");
        }
        else if(curr.data==key){
            Console.WriteLine("Element found at pos:"+ pos);
        }
        else{
            pos++;
            curr=curr.next;
            SearchListRecursively(curr, key, pos);
        }

    }
    public int GetNth(int position)
    {
        Node curr=head;
        while(position>0)
        {
            curr=curr.next;
            position--;
        }
        if(curr!=null)
        {
            return curr.data;
        }
        else
            return -1;
    }
    public void FindMiddleNode()
    {
       Node slow_ptr=head;
       Node fast_ptr=head;
       if(head!=null)
       {
           while(fast_ptr!=null & fast_ptr.next!=null)
           {
               fast_ptr=fast_ptr.next.next;
               slow_ptr=slow_ptr.next;
           }
           Console.WriteLine("The middle element is "+slow_ptr.data);
       }
    }
    public int DetectLengthOfLoop(Node head)
    {
        int length=1;
        Node curr=null;
        Node slow_ptr=head;
        Node fast_ptr=head;
        while(slow_ptr!=null && fast_ptr!=null && fast_ptr.next!=null)
        {
            slow_ptr=slow_ptr.next;
            fast_ptr=fast_ptr.next.next;
            if(slow_ptr==fast_ptr)
            {
                curr=slow_ptr;
                break;
            }
        }
        Node temp=curr;
        while(temp.next!=curr)
        {
            length++;
            temp=temp.next;
        }

        return length;
    }
    public bool IfPalindrome(Node head)
    {
        Node m=head;
        Node fast_ptr=head;
        Node slow_ptr=head;
        Node middleNode=null;
        bool isPalindrome=true;
        while(fast_ptr!=null && slow_ptr!=null && fast_ptr.next!=null)
        {
            slow_ptr=slow_ptr.next;
            fast_ptr=fast_ptr.next.next;
            if(fast_ptr==slow_ptr)
            {
                break;
            }
        }
        middleNode=slow_ptr;
       Stack<Node> stackData=new Stack<Node>();
       while(middleNode!=null)
       {
           stackData.Push(middleNode);
           middleNode=middleNode.next;
       }
       while(m!=slow_ptr.next)
       {
           Node temp=stackData.Pop();
           if(m.data==temp.data)
           {
               m=m.next;
               continue;
           }
           else
           {
               isPalindrome=false;
               break;
           }
       }
       return isPalindrome;
    }
    public bool IfPalindromeAnother(Node head)
    {
        Node curr=head;
        Stack<Node> m= new Stack<Node>();
        bool isPalindrome=true;
        while(curr!=null)
        {
            m.Push(curr);
            curr=curr.next;
        }
        Node curr2=head;
        while(curr2!=null)
        {
            Node temp=m.Pop();
            if(curr2.data == temp.data)
            {
                curr2=curr2.next;
                continue;
            }
            else{
                isPalindrome=false;
                break;
            }
        }
        return isPalindrome;
    }
    //Recursive approach to remove duplicates is the best
    public void DeleteDuplicatesSortedLinkedList(Node head)
    {
        if(head==null)
        return;
        if(head.next!=null)
            {                
                if(head.data==head.next.data)
                {
                    head.next=head.next.next;
                    DeleteDuplicatesSortedLinkedList(head);
                }
                else
                {
                    DeleteDuplicatesSortedLinkedList(head.next);
                }
            }
    }
    public void DeleteDuplicatesUnsortedLinkedList(Node head)
    {
        Node currNode=head;
        HashSet<int> set=new HashSet<int>();
        Node prev=null;
        while(currNode!=null)
        {
            if(set.Contains(currNode.data))
            {
                prev.next=currNode.next;
            }
            else{
                set.Add(currNode.data);
                prev=currNode;
            }
            currNode=currNode.next;
        }
    }
    public void PairWiseSwap(Node head)
    {
        Node currNode=head;
        while(currNode!=null && currNode.next!=null)
        {
            int temp=currNode.data;
            currNode.data=currNode.next.data;
            currNode.next.data=temp;
            currNode=currNode.next.next;
        }
    }
    //Pair wise swap recursive approach
    public void PairWiseSwapRecursive(Node head)
    {
        if(head!=null && head.next!=null)
        {
            int temp=head.data;
            head.data=head.next.data;
            head.next.data=temp;
            PairWiseSwapRecursive(head.next.next);
        }
    }
    public Node MoveLastElementAtFirst(Node head)
    {
        Node lastNode=null;
        Node currNode=head;
        Node prevNode=null;
        while(currNode.next!=null)
        {
            prevNode=currNode;
            currNode=currNode.next;
        }
        lastNode=currNode;
        prevNode.next=null;
        lastNode.next=head;
        head=lastNode;
        return head;
    }
    public Node IntersectionList(Node list1, Node list2)
    {
        Node dummyNode=new Node(-1);
        Node tail=dummyNode;
        HashSet<int> set=new HashSet<int>();
        while(list1!=null)
        {            
            set.Add(list1.data);
            list1=list1.next;
        }
        while(list2!=null)
        {
            if(set.Contains(list2.data))
            {
                tail.next=list2;
                tail=tail.next;
            }
            list2=list2.next;
        }
        tail.next=null;
        return dummyNode.next;
    }
    //The below method is not efficient, as its performance will get degraded if one of the list is large.
    public int GetIntersectionPoint(Node list1, Node list2)
    {
        HashSet<Node> set=new HashSet<Node>();
        int intersectionPoint=-1;
        while(list1!=null)
        {            
            set.Add(list1);
            list1=list1.next;
        }
        while(list2!=null)
        {
            if(set.Contains(list2))
            {
                intersectionPoint=list2.data;
                break;
            }
            list2=list2.next;
        }
        return intersectionPoint;
    }
    //Very much important
    public int GetIntersectionPoint2Pointer(Node head1, Node head2)
    {
        Node ptr1=head1;
        Node ptr2=head2;
        int intersectionPoint=-1;
        if(ptr1==null && ptr2==null)
        {
            return -1;
        }
        while(ptr1!=ptr2)
        {
            ptr1=ptr1.next;
            ptr2=ptr2.next;
            if(ptr1 == ptr2){
                intersectionPoint = ptr1.data;
            }
            if(ptr1==null){
                ptr1=head2;
            }
            if(ptr2==null){
                ptr2=head1;
            }
        }
        return intersectionPoint;
    }
    public static void Main(String[] args)
    {
        LinkedList lld=new LinkedList();
        lld.head = new Node(8);
        Node second= new Node(5);
        Node third= new Node(2);
        lld.head.next = second;
        second.next = third;
        //lld.head=lld.AddNodeAtLast(15);
        // lld.PrintList();
        //lld.head = lld.AddNodeAtStart(lld.head, 2);
        //lld.PrintList();
        //lld.head=lld.InsertNodeAtPosition(lld.head, 20, 0);
        Node m=new Node(4);
        third.next=m;
        //m.next=second;
        Node n=new Node(10);
        m.next=n;
        n.next= new Node(3);
        //bool checkPal=lld.IfPalindromeAnother(lld.head);
        //Console.WriteLine(checkPal);
        //lld.DeleteDuplicatesSortedLinkedList(lld.head);
        //lld.DeleteDuplicatesUnsortedLinkedList(lld.head);
        //lld.PairWiseSwapRecursive(lld.head);
        //lld.head=lld.MoveLastElementAtFirst(lld.head);
        //lld.PrintList();
        //lld.PrintList();
       // lld.PrintList();
        // Node fourth=new Node(2);
        // third.next=fourth;
        // third.next.next=new Node(10);
        //lld.PrintList();
        //fourth.next=head;
        //lld.AddNodeAfterGivenNode(4, 3);
        // lld.DeleteANodeWithGivenKey(5);
        // lld.DeleteNodeAtPosition(2);
        //lld.SwapPositionsOfTheseNumbers(1, 2);
        // int count=lld.NoOfNodesInCaseOfLoop();
        // if(count>0)
        // {
        //     lld.head = lld.RemoveLoop(count);
        //     lld.PrintList();
        // }
        //lld.SearchListForGivenKey(2);
        //lld.SearchListRecursively(lld.head, 2, 1);
        // int data=lld.GetNth(0);
        // if(data==-1)
        // {
        //     Console.WriteLine("Please provide an index within the range");
        // }
        // else
        // {
        // Console.WriteLine(data);
        // }
        //lld.PrintList();
        //lld.head=lld.ReverseByGroupSize(lld.head,2);
        //lld.ReverseList();
       // lld.head=lld.MergeDivide(lld.head);
        //lld.PrintList();
        LinkedList lldSecond= new LinkedList();
        lldSecond.head=new Node(1);
        lldSecond.head.next = new Node(5);
        lldSecond.head.next.next = new Node(2);
        lldSecond.head.next.next.next=second;
        //lld.head=lld.IntersectionList(lld.head, lldSecond.head);
        int intersectionPoint= lld.GetIntersectionPoint2Pointer(lld.head, lldSecond.head);
        Console.WriteLine(intersectionPoint);
        // lldSecond.PrintList();
        // lld.head = lld.MergeSortedLists(lld.head, lldSecond.head);
        // lld.PrintList();
        //int length=lld.LengthThroughRec(lld.head);
        //Console.WriteLine("Length:"+ length);
        //lld.head=lld.AddNumbersByLinkedList(lld.head, lldSecond.head);
        //lld.PrintList();
        //lld.head = lld.RotateLinkedList(3);
        //lld.PrintList();
        //lld.FindMiddleNode();
       // int loopSize=lld.DetectLengthOfLoop(lld.head);
        //Console.WriteLine(loopSize);
        Console.ReadLine();

    }
}