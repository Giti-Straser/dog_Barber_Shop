
import react,{ useState,useEffect} from 'react';
import { json } from 'react-router-dom';
import { customer } from './classes/customer.model.ts';
const baseUrl = 'http://localhost:64911/api/'

let c = {
    customer: {},
    queue:{},
    currentCustomer:{}
  };
//const result = '';
function getAllCustomers(){
    fetch(baseUrl+'Customer', { credentials: 'include'})
        .then(resp => resp.json())
        .then(data => console.log(data)
        );
}

function getCustomerByUserNameAndPassword(userName, password) {
   return fetch(baseUrl + 'Customer/' + userName + '/' + password, { credentials: 'include' })
      .then(resp => resp.json());
}


function useGetTodayQueue(){
const [result, setResult] = useState('');
useEffect(() => {
    fetch(baseUrl + 'Queue/today', { credentials: 'include' })
      .then(resp => resp.json())
      .then(data => setResult(data));
  }, []);
  console.log(result);
return result;
}

function addCustomer(name1,userName1,password1){
    c.customer = { firstName: name1,userName : userName1,password : password1 };
    console.log(c.customer)
    fetch(baseUrl+'Customer', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(c.customer)})
    .then(resp=>resp.json())
    .then(data => console.log(data))
}
function updateQueue(queueId,newtime){
  c.queue = {queueTime:newtime}
  console.log(c.queue);
  console.log(queueId);
  return fetch(baseUrl+'Queue/'+queueId,{
    method:'PUT',
    headers:{
      'Content-Type': 'application/json'
    },
    body:JSON.stringify(c.queue)
  })
  .then(resp => resp.json)
}
function deleteQueue(queueId){
  console.log('id'+queueId)
  c.queue.queueId = queueId;
  console.log(c)
  fetch(baseUrl+'Queue',{
    method:'Delete',
    headers:{
      'Content-Type': 'application/json'
    },
    body:JSON.stringify(c.queue)
  })
  .then(resp => resp.json)
}
function addQueue(time){
 c.queue.queueTime = time;
 c.queue.customerId = c.currentCustomer.customerId;
 console.log(c.queue)
 fetch(baseUrl+'Queue',{
   method:'POST',
   headers:{
    'Content-Type': 'application/json'
  },
  body:JSON.stringify(c.queue)
 })
 .then(resp=>resp.json)
}

export default {
    getAllCustomers,
    getCustomerByUserNameAndPassword,
    useGetTodayQueue,
    addCustomer,
    updateQueue,
    deleteQueue,
    addQueue,
    c
  };