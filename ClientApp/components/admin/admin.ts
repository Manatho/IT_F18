import './../../model/GalleryEntry'
import './../../model/Subscriber'
import Vue from 'vue';
import axios from "axios";
import { Component } from 'vue-property-decorator';

@Component
export default class AdminComponent extends Vue {
    subscribers: Subscriber[];
    galleryEntries: GalleryEntry[];
    aboutInfo: AboutInfo;

    newTitle: string;
    newDescription: string;
    file: FormData;


    data() {
        return {
            newTitle: '',
            newDescription: '',
            subscribers: [],
            galleryEntries: [],
            file: new FormData(),
            aboutInfo: null
        };
    }

    mounted() {
        fetch('/api/GalleryEntries')
            .then(response => response.json() as Promise<GalleryEntry[]>)
            .then(data => {
                this.galleryEntries = data;
            });

        fetch('/api/subscribers')
            .then(response => response.json() as Promise<Subscriber[]>)
            .then(data => {
                this.subscribers = data;
            });

        fetch('/api/AboutInfoes')
            .then(response => response.json() as Promise<AboutInfo[]>)
            .then(data => {
                this.aboutInfo = data[0];
            });

    }

    unsubscribe(item: Subscriber) {
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

    deleteEntry(item: GalleryEntry) {
        fetch(`/api/GalleryEntries/${item.id}`, {
            method: 'delete',
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            })
        })
            .then(() => {
                this.galleryEntries = this.galleryEntries.filter((t) => t.id !== item.id);
            });
    }

    addEntry(event: Event) {
        if (event) event.preventDefault();

        this.file.append("json", JSON.stringify(<GalleryEntry>{ title: this.newTitle, description: this.newDescription }));

        axios.post(`/api/GalleryEntries`, this.file,
            {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            })

    }

    updateAbout(event: Event) {
        fetch(`/api/aboutinfoes/${this.aboutInfo.id}`, {
            method: 'put',
            body: JSON.stringify(this.aboutInfo),
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            })
        })
    }

    fileChange(fileList: FileList) {
        this.file.set("file", fileList[0], fileList[0].name);
    }

}