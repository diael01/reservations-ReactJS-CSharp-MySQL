import React, { Component } from 'react';
import { Col, Table, Row} from 'react-bootstrap';
import { Menu } from './Menu';


export class Layout extends Component {

  render() {
      return (  
        <div>
           <Row>                                                           
                <Menu/>
           </Row>
           <Row>
                {this.props.children}             
              </Row>  
        </div>
    );
  }
}
