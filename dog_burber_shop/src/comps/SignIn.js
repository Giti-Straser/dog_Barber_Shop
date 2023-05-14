import React,{ useState } from 'react';
import './SignIn.css';
import db from '../connectToServer'
import { useNavigate } from 'react-router-dom';

function useSignIn() {
  const [name, setName] = useState('');
  const [userName, setUserName] = useState('');
  const [pass, setPass] = useState('');
  const navigate = useNavigate();
  const addCustomer = ()=>{
    db.addCustomer(name,userName,pass)
    alert(`${name} you are added Successfully`)
    navigate('/')
  }

    return (
      <div className='divv'>
        <h3 className='line'>name</h3>
          <input className='in' value={name} onChange={e => setName(e.target.value)}/>
          <h3 className='line'>user name</h3>
          <input className='in' value={userName} onChange={e => setUserName(e.target.value)}/>
          <h3 className='line'>password</h3>
          <input className='in in2' type={'password'} value={pass}  onChange={e => setPass(e.target.value)}/>
      <button className='btn' onClick={()=>addCustomer()}>Add</button>
      </div>
    )
  }
  export default useSignIn;