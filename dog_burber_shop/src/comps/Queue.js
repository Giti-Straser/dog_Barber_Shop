import React, { useState } from 'react';
import './Queue.css';
import db from '../connectToServer'
import { useNavigate  } from 'react-router-dom';

function Queue() {
  const [nameFilter, setNameFilter] = useState('');
  const [dateFilter, setDateFilter] = useState('');
  const {result, setResult} = db.useGetQueue();
  var newData = result;
  const navigate = useNavigate();
  function addQueue() {
    navigate('addQueue')
  }
  function updateQueue(queueId, customerId) {

    if (customerId !== db.c.currentCustomer.customerId) {
      alert('this is not your turn')
    }
    else {
      db.c.queue.queueId = queueId
      navigate('updateQueue')
    }
  }
  function deleteQueue(queueId, customerId) {
    if (customerId !== db.c.currentCustomer.customerId) {
      alert('this is not your turn')
    }
    else {
      db.deleteQueue(queueId);
      alert('deleted Successfully')
      setResult(newData.filter(item => item.queueId !== queueId));
    }
  }
  const filterData = () => {
    const filteredData = filterData2(newData, dateFilter,nameFilter);
return filteredData;
  }

  function filterData2(datesArray, targetDate,targetName) {
    if(targetDate){
    targetDate = new Date(targetDate)
    const targetDay = targetDate.getDate();
    const targetMonth = targetDate.getMonth();
    const targetYear = targetDate.getFullYear();

    return datesArray.filter(item => {
      const date = item.queueTime;
      const day = date.getDate();
      const month = date.getMonth();
      const year = date.getFullYear();
      return day === targetDay && month === targetMonth && year === targetYear;
    });}
    else{
      if(targetName){
        return datesArray.filter(item =>{
          return item.firstName.includes(nameFilter);
        })
      }
      else
      return datesArray;
    }
  }

  if (Array.isArray(result)) {
    newData = result.map(item => {
      const dateObject = new Date(item.queueTime);
      const dateObject2 = new Date(item.registrationTime);
      return { ...item, queueTime: dateObject, registrationTime: dateObject2 };
    });
  }

  if (newData === undefined) {
    return <div>technical problem...</div>;
  }

  return (
    <div className='divv'>
      <div className='input-container'>
        <h3>name:</h3>
        <input className='in' onChange={e => { setNameFilter(e.target.value) }} />
        <h3>date:</h3>
        <input className='in' type={'datetime-local'} onChange={e => { setDateFilter(e.target.value) }} />
      </div>
      {Array.isArray(newData) ? (
        filterData().map(item => (<div className='queue' key={item.queueId}>{item.firstName}    -  {item.queueTime.getDate()}/{item.queueTime.getMonth() + 1}/{item.queueTime.getFullYear()} - {item.queueTime.getHours()}:{item.queueTime.getMinutes()} - <button className='btnProp' onClick={() => { window.alert(`${item.firstName} - turn time - ${item.queueTime.getDate()}/${item.queueTime.getMonth() + 1}/${item.queueTime.getFullYear()} - ${item.queueTime.getHours()}:${item.queueTime.getMinutes()} - registration time - ${item.queueTime.getDate()}/${item.queueTime.getMonth() + 1}/${item.queueTime.getFullYear()}${item.registrationTime.getHours()}:${item.registrationTime.getMinutes()} `) }}>properties</button><button className='btnProp' onClick={() => updateQueue(item.queueId, item.customerId)}>update</button><button className='btnProp' onClick={() => deleteQueue(item.queueId, item.customerId)}>delete</button></div>))) : (<div>technical problem...</div>)}
      <button className='btnAdd' onClick={addQueue}>Add</button>
    </div>
  )
}
export default Queue;