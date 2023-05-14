import React,{ useState } from 'react';
import './Queue.css';
import db from '../connectToDB'
import { useNavigate } from 'react-router-dom';

function Queue() {
  const [nameFilter, setNameFilter] = useState('');
  const [dateFilter, setDateFilter] = useState('');
  const res = db.useGetTodayQueue();
  const res2 = res;
  var newData = res;
  const navigate = useNavigate();
  console.log(res);
  function addQueue(){
    console.log("add");
    navigate('addQueue')
  }
  function updateQueue(queueId,customerId){
   
    if(customerId !== db.c.currentCustomer.customerId)
    {
      alert('this is not your turn')
    }
    else{
      db.c.queue.queueId = queueId
        navigate('updateQueue')
    }
    console.log(queueId)
  }
  function deleteQueue(queueId,customerId){
    console.log('id - '+customerId+'current - '+db.c.currentCustomer.customerId)
    if(customerId !== db.c.currentCustomer.customerId)
    {
      alert('this is not your turn')
    }   
    else{
      db.deleteQueue(queueId);
      alert('deleted Successfully')
      window.location.reload();
    }
  }
  const filterData = () => {
    console.log('time - '+dateFilter+'name - '+nameFilter)
    const filteredData = newData.filter(item => {
      const date = new Date(Date.parse(dateFilter))
      //item.queueTime.setHours(item.queueTime.getHours() + 3);
      console.log(item.queueTime.getHours)
      console.log(newData)
      console.log(item)
      console.log(item.queueTime.toISOString())
      return item.firstName.includes(nameFilter) &&
             item.queueTime.toISOString().includes(dateFilter);
    });
    return filteredData;
  }


   
    if (Array.isArray(res)) {
       newData = res.map(item => {
        const dateObject = new Date(item.queueTime);
        const dateObject2 = new Date(item.registrationTime);
        return { ...item, queueTime: dateObject ,registrationTime:dateObject2};
      }); }
     
     if (newData === undefined) {
       return <div>technical problem...</div>;
     }
    
     return (
       <div className='divv'>
         <div className='input-container'>
         <h3>name:</h3>
         <input className='in'  onChange={e =>{setNameFilter(e.target.value)} }/>
         <h3>date:</h3>
         <input className='in' type={'datetime-local'} onChange={e =>{setDateFilter(e.target.value)} }/>
         </div>
         {Array.isArray(newData) ? (
        filterData().map(item => ( <div className='queue' key={item.queueId}>{item.firstName}    -  {item.queueTime.getDate()}/{item.queueTime.getMonth() + 1}/{item.queueTime.getFullYear()} - {item.queueTime.getHours()}:{item.queueTime.getMinutes()} - <button className='btnProp' onClick={()=>{window.alert(`${item.firstName} - turn time - ${item.queueTime.getDate()}/${item.queueTime.getMonth() + 1}/${item.queueTime.getFullYear()} - ${item.queueTime.getHours()}:${item.queueTime.getMinutes()} - registration time - ${item.queueTime.getDate()}/${item.queueTime.getMonth() + 1}/${item.queueTime.getFullYear()}${item.registrationTime.getHours()}:${item.registrationTime.getMinutes()} `)}}>properties</button><button className='btnProp' onClick={()=> updateQueue(item.queueId,item.customerId)}>update</button><button className='btnProp' onClick={()=> deleteQueue(item.queueId,item.customerId)}>delete</button></div>))):(<div>technical problem...</div>)}
       <button className='btnAdd' onClick={addQueue}>Add</button>
       </div>
     )
  }
  export default Queue;