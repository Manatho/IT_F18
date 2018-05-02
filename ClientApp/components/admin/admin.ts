
import './../../model/Subscriber'
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
 
@Component
export default class AdminComponent extends Vue {
    subscribers: Subscriber[];
 
    data() {
        return {
            subscribers: []
        };
    }

    mounted() {
        fetch('/api/subscribers')
            .then(response => response.json() as Promise<Subscriber[]>)
            .then(data => {
                console.log(data);
                this.subscribers = data;
            });
    }

    unsubscribe(item: Subscriber){
        fetch(`/api/subscribers/${item.id}`, {
            method: 'delete',
            headers: new Headers({
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            })
        })
        .then(() => {
            this.subscribers = this.subscribers.filter((t) => t.id !== item.id);
        });
    }
}