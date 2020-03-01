import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import { Button,  Col, ControlLabel, Form, FormControl, FormGroup } from "react-bootstrap";
import { NotificationManager } from 'react-notifications';
import { post } from './../lib/http';
import bindValueTo from '../lib/bindValueTo';


export class NameData extends Component {
  static displayName = NameData.name;

  constructor(props) {
    super(props);
  }

  save() {
    const { datacollection } = this.props;
    post('api/namedata', datacollection, (content) => {
      NotificationManager.success('Name added');
    });
  }


  render() {
    const { datacollection } = this.props;


    return (
      <div>
        <div>
          <h1>Name Addition</h1>
          <Form horizontal>
            <FormGroup controlId="FirstName">
              <Col componentClass={ControlLabel} sm={2} >
                FirstName
                        </Col>
              <Col sm={10}>
                <FormControl type="text" value={datacollection.firstname}
                  onChange={bindValueTo('datacollection.firstname')} />
              </Col>
            </FormGroup>
            <FormGroup controlId="LastName">
              <Col componentClass={ControlLabel} sm={2}>
                LastName
                        </Col>
              <Col sm={10}>
                <FormControl type="number" value={datacollection.lastname}
                  onChange={bindValueTo('datacollection.lastname')} />
              </Col>
            </FormGroup>
            <FormGroup>
              <Col smOffset={2} sm={10}>
                <Button onClick={() => this.save()}>Save</Button>
              </Col>
            </FormGroup>
            </Form>
        </div>
      </div>

    );
  }

}

NameData.defaultProps = {
  loading: false,
  datacollection: []
}