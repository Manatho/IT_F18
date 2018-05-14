import Vue from 'vue';
import './../../model/About'
import { Component } from 'vue-property-decorator';

@Component
export default class AboutComponent extends Vue {
    imageUrl : string;
    aboutInfo : AboutInfo;
    
    data(){
        return {
            imageUrl: require("./resources/images/aboutheader.png"),
            aboutInfo: null
        }
    }

    mounted() {
        fetch('/api/AboutInfoes')
            .then(response => response.json() as Promise<AboutInfo[]>)
            .then(data => {
                    this.aboutInfo = data[0];
            });

    }
}
