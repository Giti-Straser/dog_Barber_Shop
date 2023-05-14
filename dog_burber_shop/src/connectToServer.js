
import react,{ useState,useEffect} from 'react';
const baseUrl = 'http://localhost:64911/api/'

let c = {
    customer: {},
    queue:{},
    currentCustomer:{}
  };

function getCustomerByUserNameAndPassword(userName, password) {
   return fetch(baseUrl + 'Customer/' + userName + '/' + password, { credentials: 'include' })
      .then(resp => resp.json());
}


function useGetQueue(){
const [result, setResult] = useState('');
useEffect(() => {
    fetch(baseUrl + 'Queue/today', { credentials: 'include' })
      .then(resp => resp.json())
      .then(data => setResult(data));
  }, []);
return {result, setResult};
}

function addCustomer(name1,userName1,password1){
    c.customer = { firstName: name1,userName : userName1,password : password1 };
    fetch(baseUrl+'Customer', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(c.customer)})
    .then(resp=>resp.json())
}
function updateQueue(queueId,newtime){
  c.queue = {queueTime:newtime}
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
  c.queue.queueId = queueId;
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
    getCustomerByUserNameAndPassword,
    useGetQueue,
    addCustomer,
    updateQueue,
    deleteQueue,
    addQueue,
    c
  };